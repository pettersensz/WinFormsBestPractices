using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    partial class EpisodeView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EpisodeView));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.waveFormViewer1 = new PluralsightWinFormsDemoApp.Views.WaveFormViewer();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxIsFavorite = new System.Windows.Forms.CheckBox();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.labelMyNotes = new System.Windows.Forms.Label();
            this.labelMyRating = new System.Windows.Forms.Label();
            this.labelMyTags = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.topFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelEpisodeTitle = new System.Windows.Forms.Label();
            this.labelPublicationDate = new System.Windows.Forms.Label();
            this.labelEpisodeDescription = new System.Windows.Forms.Label();
            this.toolTipEpisodeView = new System.Windows.Forms.ToolTip(this.components);
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.topFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.waveFormViewer1);
            this.bottomPanel.Controls.Add(this.buttonStop);
            this.bottomPanel.Controls.Add(this.checkBoxIsFavorite);
            this.bottomPanel.Controls.Add(this.numericUpDownRating);
            this.bottomPanel.Controls.Add(this.labelMyNotes);
            this.bottomPanel.Controls.Add(this.labelMyRating);
            this.bottomPanel.Controls.Add(this.labelMyTags);
            this.bottomPanel.Controls.Add(this.textBoxNotes);
            this.bottomPanel.Controls.Add(this.textBoxTags);
            this.bottomPanel.Controls.Add(this.buttonPlay);
            resources.ApplyResources(this.bottomPanel, "bottomPanel");
            this.bottomPanel.Name = "bottomPanel";
            // 
            // waveFormViewer1
            // 
            resources.ApplyResources(this.waveFormViewer1, "waveFormViewer1");
            this.waveFormViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.waveFormViewer1.Name = "waveFormViewer1";
            this.waveFormViewer1.PositionInSeconds = 0;
            // 
            // buttonStop
            // 
            resources.ApplyResources(this.buttonStop, "buttonStop");
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsFavorite
            // 
            resources.ApplyResources(this.checkBoxIsFavorite, "checkBoxIsFavorite");
            this.checkBoxIsFavorite.Name = "checkBoxIsFavorite";
            this.checkBoxIsFavorite.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRating
            // 
            resources.ApplyResources(this.numericUpDownRating, "numericUpDownRating");
            this.numericUpDownRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRating.Name = "numericUpDownRating";
            // 
            // labelMyNotes
            // 
            resources.ApplyResources(this.labelMyNotes, "labelMyNotes");
            this.labelMyNotes.Name = "labelMyNotes";
            // 
            // labelMyRating
            // 
            resources.ApplyResources(this.labelMyRating, "labelMyRating");
            this.labelMyRating.Name = "labelMyRating";
            // 
            // labelMyTags
            // 
            resources.ApplyResources(this.labelMyTags, "labelMyTags");
            this.labelMyTags.Name = "labelMyTags";
            // 
            // textBoxNotes
            // 
            resources.ApplyResources(this.textBoxNotes, "textBoxNotes");
            this.textBoxNotes.Name = "textBoxNotes";
            // 
            // textBoxTags
            // 
            resources.ApplyResources(this.textBoxTags, "textBoxTags");
            this.textBoxTags.Name = "textBoxTags";
            // 
            // buttonPlay
            // 
            resources.ApplyResources(this.buttonPlay, "buttonPlay");
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // topFlowLayoutPanel
            // 
            resources.ApplyResources(this.topFlowLayoutPanel, "topFlowLayoutPanel");
            this.topFlowLayoutPanel.Controls.Add(this.labelEpisodeTitle);
            this.topFlowLayoutPanel.Controls.Add(this.labelPublicationDate);
            this.topFlowLayoutPanel.Controls.Add(this.labelEpisodeDescription);
            this.topFlowLayoutPanel.Name = "topFlowLayoutPanel";
            // 
            // labelEpisodeTitle
            // 
            resources.ApplyResources(this.labelEpisodeTitle, "labelEpisodeTitle");
            this.labelEpisodeTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.labelEpisodeTitle.Name = "labelEpisodeTitle";
            // 
            // labelPublicationDate
            // 
            resources.ApplyResources(this.labelPublicationDate, "labelPublicationDate");
            this.labelPublicationDate.Name = "labelPublicationDate";
            // 
            // labelEpisodeDescription
            // 
            resources.ApplyResources(this.labelEpisodeDescription, "labelEpisodeDescription");
            this.labelEpisodeDescription.Name = "labelEpisodeDescription";
            // 
            // EpisodeView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topFlowLayoutPanel);
            this.Name = "EpisodeView";
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            this.topFlowLayoutPanel.ResumeLayout(false);
            this.topFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel bottomPanel;
        internal CheckBox checkBoxIsFavorite;
        internal NumericUpDown numericUpDownRating;
        internal Label labelMyNotes;
        internal Label labelMyRating;
        internal Label labelMyTags;
        internal TextBox textBoxNotes;
        internal TextBox textBoxTags;
        internal Button buttonPlay;
        private FlowLayoutPanel topFlowLayoutPanel;
        internal Label labelEpisodeTitle;
        internal Label labelPublicationDate;
        internal Label labelEpisodeDescription;
        private ToolTip toolTipEpisodeView;
        internal Button buttonStop;
        private WaveFormViewer waveFormViewer1;
    }
}
