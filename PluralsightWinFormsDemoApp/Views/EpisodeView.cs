using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using PluralsightWinFormsDemoApp.Resources;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class EpisodeView : UserControl, IEpisodeView
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

        public string Description
        {
            get => labelEpisodeDescription.Text; 
            set => labelEpisodeDescription.Text = value;
        }

        public string Title
        {
            get => labelEpisodeTitle.Text; 
            set => labelEpisodeTitle.Text = value;
        }

        public string PublicationDate
        {
            get => labelPublicationDate.Text; 
            set => labelPublicationDate.Text = value;
        }

        public int Rating
        {
            get => (int) numericUpDownRating.Value;
            set => numericUpDownRating.Value = value;
        }
        
        public string Notes
        {
            get => textBoxNotes.Text;
            set => textBoxNotes.Text = value;
        }
        
        public string Tags
        {
            get => textBoxTags.Text;
            set => textBoxTags.Text = value;
        }
    }

    public interface IEpisodeView
    {
        string Description { set; }
        string Title { set; }
        string PublicationDate { set; }
        int Rating { get; set; }
        string Notes { get; set; }
        string Tags { get; set; }
    }
}
