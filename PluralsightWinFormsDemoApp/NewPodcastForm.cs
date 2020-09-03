using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class NewPodcastForm : Form
    {
        public NewPodcastForm()
        {
            InitializeComponent();
        }
        public string PodcastUrl { get { return textBoxFeedUrl.Text; } }

        private void OnButtonOKClick(object sender, EventArgs e)
        {
            if (!Uri.TryCreate(PodcastUrl, UriKind.Absolute, out var uri))
            {
                errorProvider1.SetError(textBoxFeedUrl, "Must be a valid url, starting with http:"); 
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
            
        }
    }
}
