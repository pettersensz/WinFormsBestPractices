using PluralsightWinFormsDemoApp.Objects;
using PluralsightWinFormsDemoApp.Properties;
using PluralsightWinFormsDemoApp.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PluralsightWinFormsDemoApp.Presenters
{
    public class MainFormPresenter
    {
        private readonly IMainFormView _mainFormView;
        private Episode _currentEpisode;
        private readonly SubscriptionManager _subscriptionManager;
        private readonly PodcastLoader _podcastLoader;
        private readonly PodcastPlayer _podcastPlayer;
        private readonly List<Podcast> _podcasts;

        private readonly ISubscriptionView _subscriptionView;
        private readonly IEpisodeView _episodeView;
        private readonly IPodcastView _podcastView;

        public MainFormPresenter(IMainFormView mainFormView)
        {
            _subscriptionView = mainFormView.SubscriptionView;
            _episodeView = mainFormView.EpisodeView;
            _podcastView = mainFormView.PodcastView;

            _mainFormView = mainFormView;
            mainFormView.Load += OnMainFormLoad;
            mainFormView.FormClosed += OnMainFormClosed;
            mainFormView.KeyUp += MainFormViewOnKeyUp;
            
            _subscriptionView.AddPodcastClicked += OnButtonAddClick;
            _subscriptionView.RemovePodcastClicked += OnButtonRemoveClick;
            _subscriptionView.SelectionChanged += OnSelectedEpisodeChanged;

            _episodeView.PlayClicked += OnButtonPlayClick;
            _episodeView.StopClicked += OnButtonStopClick;

            _subscriptionManager = new SubscriptionManager("subscriptions.xml");
            _podcastLoader = new PodcastLoader();
            _podcastPlayer = new PodcastPlayer();
            _podcasts = _subscriptionManager.LoadPodcasts();

            if (!SystemInformation.HighContrast) mainFormView.BackColor = Color.White;
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


        private void MainFormViewOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == (Keys.Space | Keys.Control))
            {
                OnButtonPlayClick(this, EventArgs.Empty);
                keyEventArgs.Handled = true;
            }
        }

        private void OnSelectedEpisodeChanged(object sender, EventArgs e)
        {
            _podcastPlayer.UnloadEpisode();
            if (_subscriptionView.SelectedNode == null) return;

            if (_subscriptionView.SelectedNode.Tag is Episode selectedEpisode)
            {
                _mainFormView.ShowEpisodeView();
                SaveEpisode();
                _currentEpisode = selectedEpisode;
                _episodeView.Title = _currentEpisode.Title;
                _episodeView.PublicationDate = _currentEpisode.PubDate;
                _episodeView.Description = _currentEpisode.Description;
                _episodeView.EpisodeIsFavorite = _currentEpisode.IsFavourite;
                _currentEpisode.IsNew = false;
                _episodeView.Rating = _currentEpisode.Rating;
                _episodeView.Tags = string.Join(",", _currentEpisode.Tags ?? new string[0]);
                _episodeView.Notes = _currentEpisode.Notes ?? "";
                _podcastPlayer.LoadEpisode(selectedEpisode);
            }

            if (!(_subscriptionView.SelectedNode.Tag is Podcast selectedPodcast)) return;
            _mainFormView.ShowPodcastView();
            _podcastView.SetPodcastTitle(selectedPodcast.Title);
            _podcastView.SetEpisodeCount($"{selectedPodcast.Episodes.Count} episodes");
        }

        private async void OnMainFormLoad(object sender, EventArgs e)
        {
            foreach (var pod in _podcasts)
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

        private void OnMainFormClosed(object sender, FormClosedEventArgs e)
        {
            SaveEpisode();
            _subscriptionManager.SavePodcasts(_podcasts);
            _podcastPlayer.Dispose();
        }

        private void SaveEpisode()
        {
            if (_currentEpisode == null) return;

            _currentEpisode.Tags = _episodeView.Tags.Split(new[] { ',' }).Select(s => s.Trim()).ToArray();
            _currentEpisode.Rating = (int)_episodeView.Rating;
            _currentEpisode.IsFavourite = _episodeView.EpisodeIsFavorite;
            _currentEpisode.Notes = _episodeView.Notes;
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

        private void AddPodcastToTreeView(Podcast pod)
        {
            var podNode = new TreeNode(pod.Title) { Tag = pod };
            _subscriptionView.AddNode(podNode);
            foreach (var episode in pod.Episodes)
            {
                podNode.Nodes.Add(new TreeNode(episode.Title) { Tag = episode });
            }
        }

        private void OnButtonRemoveClick(object sender, EventArgs e)
        {
            if (_subscriptionView.SelectedNode.Tag is Podcast podToRemove)
            {
                _podcasts.Remove(podToRemove);
                _subscriptionView.RemoveNode(podToRemove.Id.ToString());
                SelectFirstEpisode();
            }
        }

        private void SelectFirstEpisode()
        {
            _subscriptionView.SelectNode(_podcasts.SelectMany(p => p.Episodes).First().Guid);
        }


    }
}
