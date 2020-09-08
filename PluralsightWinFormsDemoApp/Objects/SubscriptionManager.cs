using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace PluralsightWinFormsDemoApp.Objects
{
    public interface ISubscriptionManager
    {
        List<Podcast> LoadPodcasts();
        void SavePodcasts(List<Podcast> podcasts);
    }
    
    internal class SubscriptionManager : ISubscriptionManager
    {
        private readonly string _file;

        public SubscriptionManager(string file)
        {
            _file = file;
        }

        public List<Podcast> LoadPodcasts()
        {
            List<Podcast> podcasts;
            if (File.Exists(_file))
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

            return podcasts;
        }

        public void SavePodcasts(List<Podcast> podcasts)
        {
            var serializer = new XmlSerializer(typeof(List<Podcast>));
            using (var s = File.Create(_file))
            {
                serializer.Serialize(s, podcasts);
            }
        }
    }
}
