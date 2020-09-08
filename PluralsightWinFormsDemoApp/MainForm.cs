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
        private readonly SubscriptionView _subscriptionView;
        private readonly EpisodeView _episodeView;
        private readonly PodcastView _podcastView;
        
        public MainForm()
        {
            InitializeComponent();

            _episodeView = new EpisodeView() {Dock = DockStyle.Fill};
            _podcastView = new PodcastView() {Dock = DockStyle.Fill};
            _subscriptionView = new SubscriptionView() {Dock = DockStyle.Fill};
            splitContainer1.Panel1.Controls.Add(_subscriptionView);
   
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
