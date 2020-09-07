using System.Windows.Forms;
using PluralsightWinFormsDemoApp.Resources;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class EpisodeView : UserControl
    {
        public EpisodeView()
        {
            InitializeComponent();
            toolTipEpisodeView.SetToolTip(textBoxTags, "Enter tags for this podcast, comma separated.");
            toolTipEpisodeView.SetToolTip(buttonPlay, "Play the podcast in windows media player.");
        }

        void TextBoxTags_HelpRequested(object sender, HelpEventArgs hlpEvent)
        {
            MessageBox.Show(TextResources.TagsHelp);
        }
    }
}
