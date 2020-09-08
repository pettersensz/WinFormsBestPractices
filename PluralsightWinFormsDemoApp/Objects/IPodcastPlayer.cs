using System.Threading.Tasks;

namespace PluralsightWinFormsDemoApp.Objects
{
    public interface IPodcastPlayer
    {
        void Dispose();
        void LoadEpisode(Episode selectedEpisode);
        void Pause();
        void Play();
        void Stop();
        void UnloadEpisode();

        Task<float[]> LoadPeaksAsync();
        int PositionInSeconds { get; set; }
    }
}