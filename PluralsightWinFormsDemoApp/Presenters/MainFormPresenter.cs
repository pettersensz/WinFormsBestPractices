using PluralsightWinFormsDemoApp.Objects;
using PluralsightWinFormsDemoApp.EventAggregator;
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
        private readonly ISubscriptionManager _subscriptionManager;
        private readonly IPodcastLoader _podcastLoader;
        private readonly IPodcastPlayer _podcastPlayer;
        private readonly List<Podcast> _podcasts;

        private readonly ISubscriptionView _subscriptionView;
        private readonly IEpisodeView _episodeView;
        private readonly IPodcastView _podcastView;
        private readonly IMessageBoxDisplayService _messageBoxDisplayService;
        private readonly ISettingsService _settingsService;
        private readonly INewSubscriptionService _newSubscriptionService;

        public MainFormPresenter(IMainFormView mainFormView,
        ISubscriptionManager subscriptionManager,
        IPodcastLoader podcastLoader,
        IPodcastPlayer podcastPlayer,
        IMessageBoxDisplayService messageBoxDisplayService,
        ISettingsService settingsService,
        ISystemInformationService systemInformationService,
        INewSubscriptionService newSubscriptionService)
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

            _subscriptionManager = subscriptionManager;
            _podcastLoader = podcastLoader;
            _podcastPlayer = podcastPlayer;
            _podcasts = _subscriptionManager.LoadPodcasts();

            _settingsService = settingsService;
            _newSubscriptionService = newSubscriptionService;
            _messageBoxDisplayService = messageBoxDisplayService;

            if (systemInformationService.IsHighContrastColorScheme) mainFormView.BackColor = Color.White;
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
                EventAggregator.EventAggregator.Instance.Publish(new EpisodeSelectedMessage(selectedEpisode));
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
                if (_currentEpisode.Peaks == null || _currentEpisode.Peaks.Length == 0)
                {
                    _episodeView.SetPeaks(null);
                    _currentEpisode.Peaks = await _podcastPlayer.LoadPeaksAsync();
                }

                _episodeView.SetPeaks(_currentEpisode.Peaks);
            }

            if (!(_subscriptionView.SelectedNode.Tag is Podcast selectedPodcast)) return;
            EventAggregator.EventAggregator.Instance.Publish(new PodcastSelectedMessage(selectedPodcast));
            _mainFormView.ShowPodcastView();
            _podcastView.SetPodcastTitle(selectedPodcast.Title);
            _podcastView.SetEpisodeCount($"{selectedPodcast.Episodes.Count} episodes");
        }

        private async void OnMainFormLoad(object sender, EventArgs e)
        {
            foreach (var pod in _podcasts)
            {
                await _podcastLoader.UpdatePodcast(pod);
                AddPodcastToTreeView(pod);
            }

            SelectFirstEpisode();

            if (!_settingsService.FirstRun) return;
            _messageBoxDisplayService.Show("Welcome! Get started by clicking Add to subscribe to a new podcast.");
            _settingsService.FirstRun = false;
            _settingsService.Save();
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
            var newPodcastUrl = _newSubscriptionService.GetSubscriptionUrl();
            if (newPodcastUrl == null) return;
            var pod = new Podcast() {SubscriptionUrl = newPodcastUrl};
            try
            {
                await _podcastLoader.UpdatePodcast(pod);
                _podcasts.Add(pod);
                AddPodcastToTreeView(pod);
            }
            catch (WebException)
            {
                _messageBoxDisplayService.Show("Sorry, that podcast could not be found. Please check the URL.");
            }
            catch (XmlException)
            {
                _messageBoxDisplayService.Show("Sorry, that URL is not a podcast feed.");
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
