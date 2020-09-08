using PluralsightWinFormsDemoApp.Objects;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.EventAggregator;

namespace PluralsightWinFormsDemoApp.Commands
{
    public class PlayCommand : CommandBase
    {
        private readonly IPodcastPlayer _player;

        public PlayCommand(IPodcastPlayer player)
        {
            _player = player;
            ToolTip = "Play";
            ShortcutKey = Keys.Space | Keys.Control;
            IsEnabled = false;
            EventAggregator.EventAggregator.Instance.Subscribe<EpisodeSelectedMessage>(e => IsEnabled = true);
            EventAggregator.EventAggregator.Instance.Subscribe<PodcastSelectedMessage>(e => IsEnabled = false);
        }

        public override void Execute()
        {
            _player.Play();
        }
    }
}
