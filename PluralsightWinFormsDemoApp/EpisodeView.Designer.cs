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
            this.labelEpisodeDescription = new System.Windows.Forms.Label();
            this.labelPublicationDate = new System.Windows.Forms.Label();
            this.labelEpisodeTitle = new System.Windows.Forms.Label();
            this.checkBoxIsFavorite = new System.Windows.Forms.CheckBox();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.labelMyNotes = new System.Windows.Forms.Label();
            this.labelMyRating = new System.Windows.Forms.Label();
            this.labelMyTags = new System.Windows.Forms.Label();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEpisodeDescription
            // 
            this.labelEpisodeDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEpisodeDescription.Location = new System.Drawing.Point(7, 55);
            this.labelEpisodeDescription.Name = "labelEpisodeDescription";
            this.labelEpisodeDescription.Size = new System.Drawing.Size(440, 51);
            this.labelEpisodeDescription.TabIndex = 23;
            this.labelEpisodeDescription.Text = "{{IN CODE}}";
            // 
            // labelPublicationDate
            // 
            this.labelPublicationDate.AutoSize = true;
            this.labelPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublicationDate.Location = new System.Drawing.Point(7, 38);
            this.labelPublicationDate.Name = "labelPublicationDate";
            this.labelPublicationDate.Size = new System.Drawing.Size(67, 13);
            this.labelPublicationDate.TabIndex = 22;
            this.labelPublicationDate.Text = "{{IN CODE}}";
            // 
            // labelEpisodeTitle
            // 
            this.labelEpisodeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEpisodeTitle.AutoEllipsis = true;
            this.labelEpisodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEpisodeTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.labelEpisodeTitle.Location = new System.Drawing.Point(7, 7);
            this.labelEpisodeTitle.Name = "labelEpisodeTitle";
            this.labelEpisodeTitle.Size = new System.Drawing.Size(440, 25);
            this.labelEpisodeTitle.TabIndex = 21;
            this.labelEpisodeTitle.Text = "{{IN CODE}}";
            // 
            // checkBoxIsFavorite
            // 
            this.checkBoxIsFavorite.AutoSize = true;
            this.checkBoxIsFavorite.Location = new System.Drawing.Point(125, 167);
            this.checkBoxIsFavorite.Name = "checkBoxIsFavorite";
            this.checkBoxIsFavorite.Size = new System.Drawing.Size(64, 17);
            this.checkBoxIsFavorite.TabIndex = 20;
            this.checkBoxIsFavorite.Text = "Favorite";
            this.checkBoxIsFavorite.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRating
            // 
            this.numericUpDownRating.Location = new System.Drawing.Point(125, 140);
            this.numericUpDownRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRating.Name = "numericUpDownRating";
            this.numericUpDownRating.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRating.TabIndex = 19;
            // 
            // labelMyNotes
            // 
            this.labelMyNotes.AutoSize = true;
            this.labelMyNotes.Location = new System.Drawing.Point(7, 185);
            this.labelMyNotes.Name = "labelMyNotes";
            this.labelMyNotes.Size = new System.Drawing.Size(55, 13);
            this.labelMyNotes.TabIndex = 16;
            this.labelMyNotes.Text = "My Notes:";
            // 
            // labelMyRating
            // 
            this.labelMyRating.AutoSize = true;
            this.labelMyRating.Location = new System.Drawing.Point(7, 142);
            this.labelMyRating.Name = "labelMyRating";
            this.labelMyRating.Size = new System.Drawing.Size(58, 13);
            this.labelMyRating.TabIndex = 17;
            this.labelMyRating.Text = "My Rating:";
            // 
            // labelMyTags
            // 
            this.labelMyTags.AutoSize = true;
            this.labelMyTags.Location = new System.Drawing.Point(7, 113);
            this.labelMyTags.Name = "labelMyTags";
            this.labelMyTags.Size = new System.Drawing.Size(51, 13);
            this.labelMyTags.TabIndex = 18;
            this.labelMyTags.Text = "My Tags:";
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotes.Location = new System.Drawing.Point(7, 204);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(440, 80);
            this.textBoxNotes.TabIndex = 15;
            // 
            // textBoxTags
            // 
            this.textBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTags.Location = new System.Drawing.Point(125, 113);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(322, 20);
            this.textBoxTags.TabIndex = 14;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPlay.Location = new System.Drawing.Point(7, 290);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 13;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // EpisodeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelEpisodeDescription);
            this.Controls.Add(this.labelPublicationDate);
            this.Controls.Add(this.labelEpisodeTitle);
            this.Controls.Add(this.checkBoxIsFavorite);
            this.Controls.Add(this.numericUpDownRating);
            this.Controls.Add(this.labelMyNotes);
            this.Controls.Add(this.labelMyRating);
            this.Controls.Add(this.labelMyTags);
            this.Controls.Add(this.textBoxNotes);
            this.Controls.Add(this.textBoxTags);
            this.Controls.Add(this.buttonPlay);
            this.Name = "EpisodeView";
            this.Size = new System.Drawing.Size(450, 350);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEpisodeDescription;
        private System.Windows.Forms.Label labelPublicationDate;
        private System.Windows.Forms.Label labelEpisodeTitle;
        private System.Windows.Forms.CheckBox checkBoxIsFavorite;
        private System.Windows.Forms.NumericUpDown numericUpDownRating;
        private System.Windows.Forms.Label labelMyNotes;
        private System.Windows.Forms.Label labelMyRating;
        private System.Windows.Forms.Label labelMyTags;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.Button buttonPlay;
    }
}
