using PluralsightWinFormsDemoApp.Objects;
using System.Windows.Forms;

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
        }

        public override void Execute()
        {
            _player.Play();
        }
    }
}
