using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public string PodcastUrl { get { return urlTextBox.Text; } }

        private void OnButtonOKClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
