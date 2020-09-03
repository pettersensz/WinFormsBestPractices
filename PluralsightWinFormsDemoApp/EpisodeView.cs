using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class EpisodeView : UserControl
    {
        public EpisodeView()
        {
            InitializeComponent();
            toolTipEpisodeView.SetToolTip(textBoxTags,"Enter tags for this podcast, comma separated.");
            toolTipEpisodeView.SetToolTip(buttonPlay, "Play the podcast in windows media player.");
        }
    }
}
