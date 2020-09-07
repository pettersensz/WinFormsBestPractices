using PluralsightWinFormsDemoApp.Objects;
using PluralsightWinFormsDemoApp.Properties;
using PluralsightWinFormsDemoApp.Views;
using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PluralsightWinFormsDemoApp
{
    public partial class MainForm : Form, IMainFormView
    {
        private Episode _currentEpisode;
        private readonly SubscriptionView _subscriptionView;
        private readonly EpisodeView _episodeView;
        private readonly PodcastView _podcastView;
        private readonly SubscriptionManager _subscriptionManager;
        private readonly PodcastLoader _podcastLoader;
        private PodcastPlayer _podcastPlayer;

        public MainForm()
        {
            InitializeComponent();

            _episodeView = new EpisodeView() {Dock = DockStyle.Fill};
            _podcastView = new PodcastView() {Dock = DockStyle.Fill};
            _subscriptionView = new SubscriptionView() {Dock = DockStyle.Fill};
            splitContainer1.Panel1.Controls.Add(_subscriptionView);

            //_subscriptionManager = new SubscriptionManager("subscriptions.xml");
            //_podcastLoader = new PodcastLoader();
            //_podcastPlayer = new PodcastPlayer();

            //_subscriptionView = new SubscriptionView
            //{
            //    Dock = DockStyle.Fill,
            //};
            //_subscriptionView.buttonAdd.Click += OnButtonAddClick;
            //_subscriptionView.buttonRemove.Click += OnButtonRemoveClick;
            //_subscriptionView.treeViewPodcasts.AfterSelect += OnSelectedEpisodeChanged;

            //_episodeView = new EpisodeView
            //{
            //    labelEpisodeDescription = { Text = "" },
            //    labelEpisodeTitle = { Text = "" },
            //    labelPublicationDate = { Text = "" },
            //    Dock = DockStyle.Fill,
            //};
            //_episodeView.buttonPlay.Click += OnButtonPlayClick;
            //_episodeView.buttonStop.Click += OnButtonStopClick;

            //_podcastView = new PodcastView
            //{
            //    Dock = DockStyle.Fill,
            //};

            //splitContainer1.Panel1.Controls.Add(_subscriptionView);

            //if (!SystemInformation.HighContrast) BackColor = Color.White;
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
            var podcasts = _subscriptionManager.LoadPodcasts();

            foreach (var pod in podcasts)
            {
                await Task.Run(() => _podcastLoader.UpdatePodcast(pod));
                AddPodcastToTreeView(pod);
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


        private void OnSelectedEpisodeChanged(object sender, TreeViewEventArgs e)
        {
            if (_subscriptionView.treeViewPodcasts.SelectedNode.Tag is Episode selectedEpisode)
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

            if (!(_subscriptionView.treeViewPodcasts.SelectedNode.Tag is Podcast selectedPodcast)) return;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(_podcastView);
            _podcastView.SetPodcastTitle(selectedPodcast.Title);
            _podcastView.SetEpisodeCount($"{selectedPodcast.Episodes.Count} episodes");
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
            if (_currentEpisode == null) return;
            _podcastPlayer.LoadEpisode(_currentEpisode);
            _podcastPlayer.Play();
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            if (_currentEpisode == null) return;
            _podcastPlayer.Stop();
        }

        private void OnButtonRemoveClick(object sender, EventArgs e)
        {
            var nodeToRemove = _subscriptionView.treeViewPodcasts.SelectedNode;
            if (nodeToRemove.Parent != null) nodeToRemove = nodeToRemove.Parent;
            _subscriptionView.treeViewPodcasts.Nodes.Remove(nodeToRemove);
            SelectFirstEpisode();
        }

        private async void OnButtonAddClick(object sender, EventArgs e)
        {
            var form = new NewPodcastForm();
            if (form.ShowDialog() != DialogResult.OK) return;
            var pod = new Podcast() { SubscriptionUrl = form.PodcastUrl };
            try
            {
                await _podcastLoader.UpdatePodcast(pod);
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
            var podcasts = _subscriptionView.treeViewPodcasts.Nodes
                .Cast<TreeNode>()
                .Select(tn => tn.Tag)
                .OfType<Podcast>()
                .ToList();
            _subscriptionManager.SavePodcasts(podcasts);
        }

        public IEpisodeView EpisodeView => _episodeView;
        public IPodcastView PodcastView => _podcastView;
        public ISubscriptionView SubscriptionView => _subscriptionView;


        public void ShowEpisodeView()
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(_episodeView);
        }

        public void ShowPodcastView()
        {
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(_podcastView);
        }
    }

    public interface IMainFormView
    {
        event EventHandler Load;
        event FormClosedEventHandler FormClosed;
        event HelpEventHandler HelpRequested;
        event KeyEventHandler KeyUp;

        IEpisodeView EpisodeView { get; }
        IPodcastView PodcastView { get; }
        ISubscriptionView SubscriptionView { get; }

        Color BackColor { get; set; }

        void ShowEpisodeView();
        void ShowPodcastView();
    }
}
