using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
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
            resources.ApplyResources(this.bottomPanel, "bottomPanel");
            this.bottomPanel.Controls.Add(this.checkBoxIsFavorite);
            this.bottomPanel.Controls.Add(this.numericUpDownRating);
            this.bottomPanel.Controls.Add(this.labelMyNotes);
            this.bottomPanel.Controls.Add(this.labelMyRating);
            this.bottomPanel.Controls.Add(this.labelMyTags);
            this.bottomPanel.Controls.Add(this.textBoxNotes);
            this.bottomPanel.Controls.Add(this.textBoxTags);
            this.bottomPanel.Controls.Add(this.buttonPlay);
            this.bottomPanel.Name = "bottomPanel";
            this.toolTipEpisodeView.SetToolTip(this.bottomPanel, resources.GetString("bottomPanel.ToolTip"));
            // 
            // checkBoxIsFavorite
            // 
            resources.ApplyResources(this.checkBoxIsFavorite, "checkBoxIsFavorite");
            this.checkBoxIsFavorite.Name = "checkBoxIsFavorite";
            this.toolTipEpisodeView.SetToolTip(this.checkBoxIsFavorite, resources.GetString("checkBoxIsFavorite.ToolTip"));
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
            this.toolTipEpisodeView.SetToolTip(this.numericUpDownRating, resources.GetString("numericUpDownRating.ToolTip"));
            // 
            // labelMyNotes
            // 
            resources.ApplyResources(this.labelMyNotes, "labelMyNotes");
            this.labelMyNotes.Name = "labelMyNotes";
            this.toolTipEpisodeView.SetToolTip(this.labelMyNotes, resources.GetString("labelMyNotes.ToolTip"));
            // 
            // labelMyRating
            // 
            resources.ApplyResources(this.labelMyRating, "labelMyRating");
            this.labelMyRating.Name = "labelMyRating";
            this.toolTipEpisodeView.SetToolTip(this.labelMyRating, resources.GetString("labelMyRating.ToolTip"));
            // 
            // labelMyTags
            // 
            resources.ApplyResources(this.labelMyTags, "labelMyTags");
            this.labelMyTags.Name = "labelMyTags";
            this.toolTipEpisodeView.SetToolTip(this.labelMyTags, resources.GetString("labelMyTags.ToolTip"));
            // 
            // textBoxNotes
            // 
            resources.ApplyResources(this.textBoxNotes, "textBoxNotes");
            this.textBoxNotes.Name = "textBoxNotes";
            this.toolTipEpisodeView.SetToolTip(this.textBoxNotes, resources.GetString("textBoxNotes.ToolTip"));
            // 
            // textBoxTags
            // 
            resources.ApplyResources(this.textBoxTags, "textBoxTags");
            this.textBoxTags.Name = "textBoxTags";
            this.toolTipEpisodeView.SetToolTip(this.textBoxTags, resources.GetString("textBoxTags.ToolTip"));
            // 
            // buttonPlay
            // 
            resources.ApplyResources(this.buttonPlay, "buttonPlay");
            this.buttonPlay.Name = "buttonPlay";
            this.toolTipEpisodeView.SetToolTip(this.buttonPlay, resources.GetString("buttonPlay.ToolTip"));
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // topFlowLayoutPanel
            // 
            resources.ApplyResources(this.topFlowLayoutPanel, "topFlowLayoutPanel");
            this.topFlowLayoutPanel.Controls.Add(this.labelEpisodeTitle);
            this.topFlowLayoutPanel.Controls.Add(this.labelPublicationDate);
            this.topFlowLayoutPanel.Controls.Add(this.labelEpisodeDescription);
            this.topFlowLayoutPanel.Name = "topFlowLayoutPanel";
            this.toolTipEpisodeView.SetToolTip(this.topFlowLayoutPanel, resources.GetString("topFlowLayoutPanel.ToolTip"));
            // 
            // labelEpisodeTitle
            // 
            resources.ApplyResources(this.labelEpisodeTitle, "labelEpisodeTitle");
            this.labelEpisodeTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.labelEpisodeTitle.Name = "labelEpisodeTitle";
            this.toolTipEpisodeView.SetToolTip(this.labelEpisodeTitle, resources.GetString("labelEpisodeTitle.ToolTip"));
            // 
            // labelPublicationDate
            // 
            resources.ApplyResources(this.labelPublicationDate, "labelPublicationDate");
            this.labelPublicationDate.Name = "labelPublicationDate";
            this.toolTipEpisodeView.SetToolTip(this.labelPublicationDate, resources.GetString("labelPublicationDate.ToolTip"));
            // 
            // labelEpisodeDescription
            // 
            resources.ApplyResources(this.labelEpisodeDescription, "labelEpisodeDescription");
            this.labelEpisodeDescription.Name = "labelEpisodeDescription";
            this.toolTipEpisodeView.SetToolTip(this.labelEpisodeDescription, resources.GetString("labelEpisodeDescription.ToolTip"));
            // 
            // EpisodeView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topFlowLayoutPanel);
            this.Name = "EpisodeView";
            this.toolTipEpisodeView.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
    }
}
