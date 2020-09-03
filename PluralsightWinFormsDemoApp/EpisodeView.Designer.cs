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
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.topFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.checkBoxIsFavorite);
            this.bottomPanel.Controls.Add(this.numericUpDownRating);
            this.bottomPanel.Controls.Add(this.labelMyNotes);
            this.bottomPanel.Controls.Add(this.labelMyRating);
            this.bottomPanel.Controls.Add(this.labelMyTags);
            this.bottomPanel.Controls.Add(this.textBoxNotes);
            this.bottomPanel.Controls.Add(this.textBoxTags);
            this.bottomPanel.Controls.Add(this.buttonPlay);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(0, 51);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(924, 447);
            this.bottomPanel.TabIndex = 0;
            // 
            // checkBoxIsFavorite
            // 
            this.checkBoxIsFavorite.AutoSize = true;
            this.checkBoxIsFavorite.Location = new System.Drawing.Point(120, 63);
            this.checkBoxIsFavorite.Name = "checkBoxIsFavorite";
            this.checkBoxIsFavorite.Size = new System.Drawing.Size(64, 17);
            this.checkBoxIsFavorite.TabIndex = 4;
            this.checkBoxIsFavorite.Text = "&Favorite";
            this.checkBoxIsFavorite.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRating
            // 
            this.numericUpDownRating.Location = new System.Drawing.Point(120, 36);
            this.numericUpDownRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRating.Name = "numericUpDownRating";
            this.numericUpDownRating.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRating.TabIndex = 3;
            // 
            // labelMyNotes
            // 
            this.labelMyNotes.AutoSize = true;
            this.labelMyNotes.Location = new System.Drawing.Point(2, 81);
            this.labelMyNotes.Name = "labelMyNotes";
            this.labelMyNotes.Size = new System.Drawing.Size(55, 13);
            this.labelMyNotes.TabIndex = 5;
            this.labelMyNotes.Text = "My &Notes:";
            // 
            // labelMyRating
            // 
            this.labelMyRating.AutoSize = true;
            this.labelMyRating.Location = new System.Drawing.Point(2, 38);
            this.labelMyRating.Name = "labelMyRating";
            this.labelMyRating.Size = new System.Drawing.Size(58, 13);
            this.labelMyRating.TabIndex = 2;
            this.labelMyRating.Text = "My &Rating:";
            // 
            // labelMyTags
            // 
            this.labelMyTags.AutoSize = true;
            this.labelMyTags.Location = new System.Drawing.Point(2, 9);
            this.labelMyTags.Name = "labelMyTags";
            this.labelMyTags.Size = new System.Drawing.Size(51, 13);
            this.labelMyTags.TabIndex = 0;
            this.labelMyTags.Text = "My &Tags:";
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotes.Location = new System.Drawing.Point(1, 97);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(920, 318);
            this.textBoxNotes.TabIndex = 6;
            // 
            // textBoxTags
            // 
            this.textBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTags.Location = new System.Drawing.Point(120, 9);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(802, 20);
            this.textBoxTags.TabIndex = 1;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPlay.Location = new System.Drawing.Point(0, 421);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 7;
            this.buttonPlay.Text = "&Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // topFlowLayoutPanel
            // 
            this.topFlowLayoutPanel.AutoSize = true;
            this.topFlowLayoutPanel.Controls.Add(this.labelEpisodeTitle);
            this.topFlowLayoutPanel.Controls.Add(this.labelPublicationDate);
            this.topFlowLayoutPanel.Controls.Add(this.labelEpisodeDescription);
            this.topFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.topFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.topFlowLayoutPanel.Name = "topFlowLayoutPanel";
            this.topFlowLayoutPanel.Size = new System.Drawing.Size(924, 51);
            this.topFlowLayoutPanel.TabIndex = 25;
            this.topFlowLayoutPanel.WrapContents = false;
            // 
            // labelEpisodeTitle
            // 
            this.labelEpisodeTitle.AutoSize = true;
            this.labelEpisodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEpisodeTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.labelEpisodeTitle.Location = new System.Drawing.Point(3, 0);
            this.labelEpisodeTitle.Name = "labelEpisodeTitle";
            this.labelEpisodeTitle.Size = new System.Drawing.Size(126, 25);
            this.labelEpisodeTitle.TabIndex = 0;
            this.labelEpisodeTitle.Text = "{{IN CODE}}";
            // 
            // labelPublicationDate
            // 
            this.labelPublicationDate.AutoSize = true;
            this.labelPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublicationDate.Location = new System.Drawing.Point(3, 25);
            this.labelPublicationDate.Name = "labelPublicationDate";
            this.labelPublicationDate.Size = new System.Drawing.Size(67, 13);
            this.labelPublicationDate.TabIndex = 1;
            this.labelPublicationDate.Text = "{{IN CODE}}";
            // 
            // labelEpisodeDescription
            // 
            this.labelEpisodeDescription.AutoSize = true;
            this.labelEpisodeDescription.Location = new System.Drawing.Point(3, 38);
            this.labelEpisodeDescription.MaximumSize = new System.Drawing.Size(10000, 150);
            this.labelEpisodeDescription.Name = "labelEpisodeDescription";
            this.labelEpisodeDescription.Size = new System.Drawing.Size(67, 13);
            this.labelEpisodeDescription.TabIndex = 2;
            this.labelEpisodeDescription.Text = "{{IN CODE}}";
            // 
            // EpisodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topFlowLayoutPanel);
            this.Name = "EpisodeView";
            this.Size = new System.Drawing.Size(924, 498);
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
    }
}
