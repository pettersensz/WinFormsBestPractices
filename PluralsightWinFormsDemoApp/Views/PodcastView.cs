using System;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.Objects;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class PodcastView : UserControl, IPodcastView
    {
        public PodcastView()
        {
            InitializeComponent();
        }

        public void SetPodcastTitle(string podcastTitle)
        {
            labelPodcastTitle.Text = podcastTitle;
        }

        public void SetEpisodeCount(string episodeCount)
        {
            labelEpisodeCount.Text = episodeCount;
        }
    }

    public interface IPodcastView
    {
        void SetPodcastTitle(string podcastTitle);
        void SetEpisodeCount(string episodeCount);
    }
}
