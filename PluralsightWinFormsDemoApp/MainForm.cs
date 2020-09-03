using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PluralsightWinFormsDemoApp
{
    public partial class MainForm : Form
    {
        private Episode _currentEpisode;

        public MainForm()
        {
            InitializeComponent();
            listBoxEpisodes.DisplayMember = "Title";
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            List<Podcast> podcasts;
            if (File.Exists("subscriptions.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Podcast>));
                using (var s = File.OpenRead("subscriptions.xml"))
                {
                    podcasts = (List<Podcast>) serializer.Deserialize(s);
                }
            }
            else
            {
                var defaultFeeds = new[]
                {
                    "http://hwpod.libsyn.com/rss",
                    "http://feeds.feedburner.com/herdingcode",
                    "http://www.pwop.com/feed.aspx?show=dotnetrocks&amp;filetype=master",
                    "http://feeds.feedburner.com/JesseLibertyYapcast",
                    "http://feeds.feedburner.com/HanselminutesCompleteMP3"
                };
                podcasts = defaultFeeds.Select(f => new Podcast() { SubscriptionUrl = f }).ToList();
            }

            listBoxPodcasts.DisplayMember = "Title";

            foreach (var pod in podcasts)
            {
                UpdatePodcast(pod);
                listBoxPodcasts.Items.Add(pod);
            }
        }

        void UpdatePodcast(Podcast podcast)
        {
            var doc = new XmlDocument();
            doc.Load(podcast.SubscriptionUrl);

            var channel = doc["rss"]["channel"];
            var items = channel.GetElementsByTagName("item");
            podcast.Title = channel["title"].InnerText;
            podcast.Link = channel["link"].InnerText;
            podcast.Description = channel["description"].InnerText;
            if (podcast.Episodes == null) podcast.Episodes = new List<Episode>();
            foreach (XmlNode item in items)
            {
                var guid = item["guid"].InnerText;
                var episode = podcast.Episodes.FirstOrDefault(e => e.Guid == guid);
                if (episode != null) continue;
                episode = new Episode
                {
                    Guid = guid,
                    IsNew = true,
                    Title = item["title"].InnerText,
                    PubDate = item["pubDate"].InnerText
                };
                var xmlElement = item["description"];
                if (xmlElement != null) episode.Description = xmlElement.InnerText;
                var element = item["link"];
                if (element != null) episode.Link = element.InnerText;
                var enclosureElement = item["enclosure"];
                if (enclosureElement != null) episode.AudioFile = enclosureElement.Attributes["url"].InnerText;
                podcast.Episodes.Add(episode);
            }
        }

        private void OnSelectedPodcastChanged(object sender, EventArgs e)
        {
            if (listBoxPodcasts.SelectedIndex == -1) return;
            var pod = (Podcast)listBoxPodcasts.SelectedItem;
            listBoxEpisodes.DataSource = pod.Episodes;
        }

        private void OnSelectedEpisodeChanged(object sender, EventArgs e)
        {
            SaveEpisode();
            _currentEpisode = (Episode)listBoxEpisodes.SelectedItem;
            textBoxEpisodeTitle.Text = _currentEpisode.Title;
            textBoxPublicationDate.Text = _currentEpisode.PubDate;
            textBoxDescription.Text = _currentEpisode.Description;
            checkBoxIsFavorite.Checked = _currentEpisode.IsFavourite;
            _currentEpisode.IsNew = false;
            numericUpDownRating.Value = _currentEpisode.Rating;
            textBoxTags.Text = string.Join(",", _currentEpisode.Tags ?? new string[0]);
            textBoxNotes.Text = _currentEpisode.Notes ?? "";
        }

        private void SaveEpisode()
        {
            if (_currentEpisode == null) return;

            _currentEpisode.Tags = textBoxTags.Text.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            _currentEpisode.Rating = (int)numericUpDownRating.Value;
            _currentEpisode.IsFavourite = checkBoxIsFavorite.Checked;
            _currentEpisode.Notes = textBoxNotes.Text;
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            Process.Start(_currentEpisode.AudioFile ?? _currentEpisode.Link);
        }

        private void OnButtonRemoveClick(object sender, EventArgs e)
        {
            listBoxPodcasts.Items.Remove(listBoxPodcasts.SelectedItem);
            listBoxPodcasts.SelectedIndex = 0;
        }

        private void OnButtonAddClick(object sender, EventArgs e)
        {
            var form = new NewPodcastForm();
            if (form.ShowDialog() != DialogResult.OK) return;
            var pod = new Podcast() {SubscriptionUrl = form.PodcastUrl };
            UpdatePodcast(pod);
            var index = listBoxPodcasts.Items.Add(pod.Title);
            listBoxPodcasts.SelectedIndex = index;
        }

        private void OnMainFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveEpisode();
            var serializer = new XmlSerializer(typeof(List<Podcast>));
            using (var s = File.Create("subscriptions.xml"))
            {
                serializer.Serialize(s, listBoxPodcasts.Items.Cast<Podcast>().ToList());
            }
        }
    }
}
