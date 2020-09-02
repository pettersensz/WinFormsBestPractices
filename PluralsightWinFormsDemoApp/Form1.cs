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
        private Episode currentEpisode;
        private EpisodeView episodeView;
        //private SubscriptionViewOld subscriptionView;
        private SubscriptionView subscriptionView;
        private PodcastView podcastView;

        public MainForm()
        {
            InitializeComponent();

            //subscriptionView = new SubscriptionView() {Dock = DockStyle.Fill};
            //subscriptionView.listBoxEpisodes.DisplayMember = "Title";
            //subscriptionView.listBoxEpisodes.SelectedIndexChanged += OnSelectedEpisodeChanged;
            //subscriptionView.listBoxPodcasts.SelectedIndexChanged += OnSelectedPodcastChanged;
            //subscriptionView.AddButton.Click += OnButtonAddClick;
            //subscriptionView.RemoveButton.Click += OnButtonRemoveClick;
            //splitContainer1.Panel1.Controls.Add(subscriptionView);

            subscriptionView = new SubscriptionView() {Dock = DockStyle.Fill};
            subscriptionView.treeViewPodcasts.AfterSelect += OnSelectedEpisodeChangedTreeView;
            subscriptionView.buttonAddSubscription.Click += OnButtonAddClick;
            subscriptionView.buttonRemoveSubscription.Click += OnButtonRemoveClick;
            //splitContainer1.Panel1.Controls.Add(subscriptionView);

            episodeView = new EpisodeView() {Dock = DockStyle.Fill};
            episodeView.labelEpisodeTitle.Text = "";
            episodeView.labelPublicationDate.Text = "";
            episodeView.labelDescription.Text = "";
            episodeView.buttonPlay.Click += OnButtonPlayClick;
            //splitContainer1.Panel2.Controls.Add(episodeView);

            podcastView = new PodcastView() {Dock = DockStyle.Fill};
        }

        private void OnForm1Load(object sender, EventArgs e)
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

            //subscriptionView.listBoxPodcasts.DisplayMember = "Title";

            foreach (var pod in podcasts)
            {
                UpdatePodcast(pod);
                AddPodcastToTreeView(pod);
                //subscriptionView.listBoxPodcasts.Items.Add(pod);
            }

            SelectFirstEpisode();
        }

        private void SelectFirstEpisode()
        {
            subscriptionView.treeViewPodcasts.SelectedNode =
                subscriptionView.treeViewPodcasts.Nodes[0].FirstNode;
        }

        private void AddPodcastToTreeView(Podcast pod)
        {
            var podNode = new TreeNode(pod.Title) {Tag = pod};
            subscriptionView.treeViewPodcasts.Nodes.Add(podNode);
            foreach (var episode in pod.Episodes)
            {
                podNode.Nodes.Add(new TreeNode(episode.Title) {Tag = episode});
            }
        }

        void UpdatePodcast(Podcast podcast)
        {
            var doc = new XmlDocument();
            doc.Load(podcast.SubscriptionUrl);

            XmlElement channel = doc["rss"]["channel"];
            XmlNodeList items = channel.GetElementsByTagName("item");
            podcast.Title = channel["title"].InnerText;
            podcast.Link = channel["link"].InnerText;
            podcast.Description = channel["description"].InnerText;
            if (podcast.Episodes == null) podcast.Episodes = new List<Episode>();
            foreach (XmlNode item in items)
            {
                var guid = item["guid"].InnerText;
                var episode = podcast.Episodes.FirstOrDefault(e => e.Guid == guid);
                if (episode == null)
                {
                    episode = new Episode() { Guid = guid, IsNew = true};
                    episode.Title = item["title"].InnerText;
                    episode.PubDate = item["pubDate"].InnerText;
                    var xmlElement = item["description"];
                    if (xmlElement != null) episode.Description = xmlElement.InnerText;
                    var element = item["link"];
                    if (element != null) episode.Link = element.InnerText;
                    var enclosureElement = item["enclosure"];
                    if (enclosureElement != null) episode.AudioFile = enclosureElement.Attributes["url"].InnerText;
                    podcast.Episodes.Add(episode);
                }
            }
        }

        private void OnSelectedPodcastChanged(object sender, EventArgs e)
        {
            if (subscriptionView.listBoxPodcasts.SelectedIndex == -1) return;
            var pod = (Podcast)subscriptionView.listBoxPodcasts.SelectedItem;
            subscriptionView.listBoxEpisodes.DataSource = pod.Episodes;
        }

        private void OnSelectedEpisodeChanged(object sender, EventArgs e)
        {
            SaveEpisode();
            currentEpisode = (Episode)subscriptionView.listBoxEpisodes.SelectedItem;
            episodeView.labelEpisodeTitle.Text = currentEpisode.Title;
            episodeView.labelPublicationDate.Text = currentEpisode.PubDate;
            episodeView.labelDescription.Text = currentEpisode.Description;
            episodeView.checkBoxIsFavourite.Checked = currentEpisode.IsFavourite;
            currentEpisode.IsNew = false;
            episodeView.numericUpDownRating.Value = currentEpisode.Rating;
            episodeView.textBoxTags.Text = String.Join(",", currentEpisode.Tags ?? new string[0]);
            episodeView.textBoxNotes.Text = currentEpisode.Notes ?? "";
        }

        private void OnSelectedEpisodeChangedTreeView(object sender, TreeViewEventArgs e)
        {
            var selectedEpisode = subscriptionView.treeViewPodcasts.SelectedNode.Tag as Episode;
            if (selectedEpisode != null)
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(episodeView);
                SaveEpisode();
                currentEpisode = selectedEpisode;
                episodeView.labelEpisodeTitle.Text = currentEpisode.Title;
                episodeView.labelPublicationDate.Text = currentEpisode.PubDate;
                episodeView.labelDescription.Text = currentEpisode.Description;
                episodeView.checkBoxIsFavourite.Checked = currentEpisode.IsFavourite;
                currentEpisode.IsNew = false;
                episodeView.numericUpDownRating.Value = currentEpisode.Rating;
                episodeView.textBoxTags.Text = String.Join(",", currentEpisode.Tags ?? new string[0]);
                episodeView.textBoxNotes.Text = currentEpisode.Notes ?? "";
            }

            var selectedPodcast = subscriptionView.treeViewPodcasts.SelectedNode.Tag as Podcast;
            if (selectedPodcast != null)
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(podcastView);
                podcastView.SetPodcast(selectedPodcast);
            }
        }

        private void SaveEpisode()
        {
            if (currentEpisode == null) return;

            currentEpisode.Tags = episodeView.textBoxTags.Text.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            currentEpisode.Rating = (int)episodeView.numericUpDownRating.Value;
            currentEpisode.IsFavourite = episodeView.checkBoxIsFavourite.Checked;
            currentEpisode.Notes = episodeView.textBoxNotes.Text;
        }

        private void OnButtonPlayClick(object sender, EventArgs e)
        {
            Process.Start(currentEpisode.AudioFile ?? currentEpisode.Link);
        }

        private void OnButtonRemoveClick(object sender, EventArgs e)
        {
            var nodeToRemove = subscriptionView.treeViewPodcasts.SelectedNode;
            if (nodeToRemove.Parent != null)
                nodeToRemove = nodeToRemove.Parent;
            subscriptionView.treeViewPodcasts.Nodes.Remove(nodeToRemove);
            SelectFirstEpisode();

            //subscriptionView.listBoxPodcasts.Items.Remove(subscriptionView.listBoxPodcasts.SelectedItem);
            //subscriptionView.listBoxPodcasts.SelectedIndex = 0;
        }

        private void OnButtonAddClick(object sender, EventArgs e)
        {
            var form = new NewPodcastForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var pod = new Podcast() {SubscriptionUrl = form.PodcastUrl };
                UpdatePodcast(pod);
                AddPodcastToTreeView(pod);

                //var index = subscriptionView.listBoxPodcasts.Items.Add(pod.Title);
                //subscriptionView.listBoxPodcasts.SelectedIndex = index;
            }
        }

        private void OnForm1Closed(object sender, FormClosedEventArgs e)
        {
            SaveEpisode();
            var serializer = new XmlSerializer(typeof(List<Podcast>));
            using (var s = File.Create("subscriptions.xml"))
            {
                var podcasts = subscriptionView.treeViewPodcasts.Nodes
                    .Cast<TreeNode>()
                    .Select(tn => tn.Tag)
                    .OfType<Podcast>()
                    .ToList();
                serializer.Serialize(s,podcasts);

                //serializer.Serialize(s, subscriptionView.listBoxPodcasts.Items.Cast<Podcast>().ToList());
            }
        }
    }
}
