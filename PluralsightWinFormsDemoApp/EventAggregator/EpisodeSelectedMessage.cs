using System.Drawing.Text;
using PluralsightWinFormsDemoApp.Objects;

namespace PluralsightWinFormsDemoApp.EventAggregator
{
    public class EpisodeSelectedMessage : IApplicationEvent
    {
        public EpisodeSelectedMessage(Episode episode)
        {
            Episode = episode;
        }
        
        public Episode Episode
        {
            get;
            private set;
        }
    }

    public class PodcastSelectedMessage : IApplicationEvent
    {
        public PodcastSelectedMessage(Podcast podcast)
        {
            Podcast = podcast;
        }

        public Podcast Podcast
        {
            get;
            private set;
        }
    }
}
