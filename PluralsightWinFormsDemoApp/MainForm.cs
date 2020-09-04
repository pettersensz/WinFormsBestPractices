using PluralsightWinFormsDemoApp.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PluralsightWinFormsDemoApp
{
    public partial class MainForm : Form
    {
        private Episode _currentEpisode;
        private readonly SubscriptionView _subscriptionView;
        private readonly EpisodeView _episodeView;
        private readonly PodcastView _podcastView;

        public MainForm()
        {
            InitializeComponent();

            _subscriptionView = new SubscriptionView
            {
                Dock = DockStyle.Fill,
            };
            _subscriptionView.buttonAdd.Click += OnButtonAddClick;
            _subscriptionView.buttonRemove.Click += OnButtonRemoveClick;
            _subscriptionView.treeViewPodcasts.AfterSelect += OnSelectedEpisodeChanged;

            _episodeView = new EpisodeView
            {
                labelEpisodeDescription = { Text = "" },
                labelEpisodeTitle = { Text = "" },
                labelPublicationDate = { Text = "" },
                Dock = DockStyle.Fill,
            };
            _episodeView.buttonPlay.Click += OnButtonPlayClick;

            _podcastView = new PodcastView
            {
                Dock = DockStyle.Fill,
            };

            splitContainer1.Panel1.Controls.Add(_subscriptionView);

            if (!SystemInformation.HighContrast) BackColor = Color.White;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Space | Keys.Control))
            {
                _episodeView.buttonPlay.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void OnMainFormLoad(object sender, EventArgs e)
        {
            List<Podcast> podcasts;
            if (File.Exists("subscriptions.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Podcast>));
                using (var s = File.OpenRead("subscriptions.xml"))
                {
                    podcasts = (List<Podcast>)serializer.Deserialize(s);
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

            foreach (var pod in podcasts)
            {
                var updatePodcastTask = Task.Run(() => UpdatePodcast(pod));
                var firstTask = await Task.WhenAny(updatePodcastTask, Task.Delay(2000));
                if(firstTask == updatePodcastTask)
                {
                    AddPodcastToTreeView(pod);
                }
            }

            SelectFirstEpisode();

            if (Settings.Default.FirstRun)
            {
                MessageBox.Show("Welcome! Get started by clicking Add to subscribe to a new podcast.");
                Settings.Default.FirstRun = false;
                Settings.Default.Save();
            }
        }

        private void SelectFirstEpisode()
        {
            _subscriptionView.treeViewPodcasts.SelectedNode = _subscriptionView.treeViewPodcasts.Nodes[0].FirstNode;
        }

        private void AddPodcastToTreeView(Podcast pod)
        {
            var podNode = new TreeNode(pod.Title) { Tag = pod };
            _subscriptionView.treeViewPodcasts.Nodes.Add(podNode);
            foreach (var episode in pod.Episodes)
            {
                podNode.Nodes.Add(new TreeNode(episode.Title) { Tag = episode });
            }
        }

        void UpdatePodcast(Podcast podcast)
        {
            var r = new Random();
            Thread.Sleep(r.Next(3000));
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

        private void OnSelectedEpisodeChanged(object sender, TreeViewEventArgs e)
        {
            Episode selectedEpisode = _subscriptionView.treeViewPodcasts.SelectedNode.Tag as Episode;
            if (selectedEpisode != null)
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(_episodeView);
                SaveEpisode();
                _currentEpisode = selectedEpisode;
                _episodeView.labelEpisodeTitle.Text = _currentEpisode.Title;
                _episodeView.labelPublicationDate.Text = _currentEpisode.PubDate;
                _episodeView.labelEpisodeDescription.Text = _currentEpisode.Description;
                _episodeView.checkBoxIsFavorite.Checked = _currentEpisode.IsFavourite;
                _currentEpisode.IsNew = false;
                _episodeView.numericUpDownRating.Value = _currentEpisode.Rating;
                _episodeView.textBoxTags.Text = string.Join(",", _currentEpisode.Tags ?? new string[0]);
                _episodeView.textBoxNotes.Text = _currentEpisode.Notes ?? "";
            }
            Podcast selectedPodcast = _subscriptionView.treeViewPodcasts.SelectedNode.Tag as Podcast;
            if (selectedPodcast != null)
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(_podcastView);
                _podcastView.SetPodcast(selectedPodcast);
            }
        }

        private void SaveEpisode()
        {
            if (_currentEpisode == null) return;

            _currentEpisode.Tags = _episodeView.textBoxTags.Text.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            _currentEpisode.Rating = (int)_episodeView.numericUpDownRating.Value;
            _currentEpisode.IsFavourite = _episodeView.checkBoxIsFavorite.Checked;
            _currentEpisode.Notes = _episodeView.textBoxNotes.Text;
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            Process.Start(_currentEpisode.AudioFile ?? _currentEpisode.Link);
        }

        private void OnButtonRemoveClick(object sender, EventArgs e)
        {
            var nodeToRemove = _subscriptionView.treeViewPodcasts.SelectedNode;
            if (nodeToRemove.Parent != null) nodeToRemove = nodeToRemove.Parent;
            _subscriptionView.treeViewPodcasts.Nodes.Remove(nodeToRemove);
            SelectFirstEpisode();
        }

        private void OnButtonAddClick(object sender, EventArgs e)
        {
            var form = new NewPodcastForm();
            if (form.ShowDialog() != DialogResult.OK) return;
            var pod = new Podcast() { SubscriptionUrl = form.PodcastUrl };
            try
            {
                UpdatePodcast(pod);
                AddPodcastToTreeView(pod);
            }
            catch (WebException)
            {
                MessageBox.Show("Sorry, that podcast could not be found. Please check the URL.");
            }
            catch (XmlException)
            {
                MessageBox.Show("Sorry, that URL is not a podcast feed.");
            }
        }

        private void OnMainFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveEpisode();
            var serializer = new XmlSerializer(typeof(List<Podcast>));
            using (var s = File.Create("subscriptions.xml"))
            {
                var podcasts = _subscriptionView.treeViewPodcasts.Nodes
                .Cast<TreeNode>()
                .Select(tn => tn.Tag)
                .OfType<Podcast>()
                .ToList();
                serializer.Serialize(s, podcasts);
            }
        }
    }
}
