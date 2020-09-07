using System;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.Objects;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class PodcastView : UserControl
    {
        public PodcastView()
        {
            InitializeComponent();
        }

        internal void SetPodcast(Podcast selectedPodcast)
        {
            podcastTitle.Text = selectedPodcast.Title;
            labelEpisodeCount.Text = String.Format("{0} episodes",selectedPodcast.Episodes.Count);
        }
    }
}
