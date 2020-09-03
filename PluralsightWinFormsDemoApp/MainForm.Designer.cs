namespace PluralsightWinFormsDemoApp
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxPodcasts = new System.Windows.Forms.ListBox();
            this.listBoxEpisodes = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.textBoxNotes = new System.Windows.Forms.TextBox();
            this.labelMyTags = new System.Windows.Forms.Label();
            this.labelMyNotes = new System.Windows.Forms.Label();
            this.numericUpDownRating = new System.Windows.Forms.NumericUpDown();
            this.labelMyRating = new System.Windows.Forms.Label();
            this.checkBoxIsFavorite = new System.Windows.Forms.CheckBox();
            this.labelEpisodeTitle = new System.Windows.Forms.Label();
            this.labelPublicationDate = new System.Windows.Forms.Label();
            this.labelEpisodeDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxPodcasts
            // 
            this.listBoxPodcasts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPodcasts.FormattingEnabled = true;
            this.listBoxPodcasts.Location = new System.Drawing.Point(13, 13);
            this.listBoxPodcasts.Name = "listBoxPodcasts";
            this.listBoxPodcasts.Size = new System.Drawing.Size(191, 316);
            this.listBoxPodcasts.TabIndex = 0;
            this.listBoxPodcasts.SelectedIndexChanged += new System.EventHandler(this.OnSelectedPodcastChanged);
            // 
            // listBoxEpisodes
            // 
            this.listBoxEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEpisodes.FormattingEnabled = true;
            this.listBoxEpisodes.Location = new System.Drawing.Point(211, 13);
            this.listBoxEpisodes.Name = "listBoxEpisodes";
            this.listBoxEpisodes.Size = new System.Drawing.Size(216, 316);
            this.listBoxEpisodes.TabIndex = 1;
            this.listBoxEpisodes.SelectedIndexChanged += new System.EventHandler(this.OnSelectedEpisodeChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(13, 335);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.OnButtonAddClick);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.Location = new System.Drawing.Point(94, 335);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 2;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.OnButtonRemoveClick);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPlay.Location = new System.Drawing.Point(459, 335);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 3;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.OnButtonPlayClick);
            // 
            // textBoxTags
            // 
            this.textBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTags.Location = new System.Drawing.Point(577, 119);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(193, 20);
            this.textBoxTags.TabIndex = 4;
            // 
            // textBoxNotes
            // 
            this.textBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotes.Location = new System.Drawing.Point(459, 210);
            this.textBoxNotes.Multiline = true;
            this.textBoxNotes.Name = "textBoxNotes";
            this.textBoxNotes.Size = new System.Drawing.Size(311, 119);
            this.textBoxNotes.TabIndex = 6;
            // 
            // labelMyTags
            // 
            this.labelMyTags.AutoSize = true;
            this.labelMyTags.Location = new System.Drawing.Point(459, 119);
            this.labelMyTags.Name = "labelMyTags";
            this.labelMyTags.Size = new System.Drawing.Size(51, 13);
            this.labelMyTags.TabIndex = 7;
            this.labelMyTags.Text = "My Tags:";
            // 
            // labelMyNotes
            // 
            this.labelMyNotes.AutoSize = true;
            this.labelMyNotes.Location = new System.Drawing.Point(459, 191);
            this.labelMyNotes.Name = "labelMyNotes";
            this.labelMyNotes.Size = new System.Drawing.Size(55, 13);
            this.labelMyNotes.TabIndex = 7;
            this.labelMyNotes.Text = "My Notes:";
            // 
            // numericUpDownRating
            // 
            this.numericUpDownRating.Location = new System.Drawing.Point(577, 146);
            this.numericUpDownRating.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRating.Name = "numericUpDownRating";
            this.numericUpDownRating.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownRating.TabIndex = 8;
            // 
            // labelMyRating
            // 
            this.labelMyRating.AutoSize = true;
            this.labelMyRating.Location = new System.Drawing.Point(459, 148);
            this.labelMyRating.Name = "labelMyRating";
            this.labelMyRating.Size = new System.Drawing.Size(58, 13);
            this.labelMyRating.TabIndex = 7;
            this.labelMyRating.Text = "My Rating:";
            // 
            // checkBoxIsFavorite
            // 
            this.checkBoxIsFavorite.AutoSize = true;
            this.checkBoxIsFavorite.Location = new System.Drawing.Point(577, 173);
            this.checkBoxIsFavorite.Name = "checkBoxIsFavorite";
            this.checkBoxIsFavorite.Size = new System.Drawing.Size(64, 17);
            this.checkBoxIsFavorite.TabIndex = 9;
            this.checkBoxIsFavorite.Text = "Favorite";
            this.checkBoxIsFavorite.UseVisualStyleBackColor = true;
            // 
            // labelEpisodeTitle
            // 
            this.labelEpisodeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEpisodeTitle.AutoEllipsis = true;
            this.labelEpisodeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEpisodeTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.labelEpisodeTitle.Location = new System.Drawing.Point(459, 13);
            this.labelEpisodeTitle.Name = "labelEpisodeTitle";
            this.labelEpisodeTitle.Size = new System.Drawing.Size(311, 25);
            this.labelEpisodeTitle.TabIndex = 10;
            this.labelEpisodeTitle.Text = "{{IN CODE}}";
            // 
            // labelPublicationDate
            // 
            this.labelPublicationDate.AutoSize = true;
            this.labelPublicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPublicationDate.Location = new System.Drawing.Point(459, 44);
            this.labelPublicationDate.Name = "labelPublicationDate";
            this.labelPublicationDate.Size = new System.Drawing.Size(67, 13);
            this.labelPublicationDate.TabIndex = 11;
            this.labelPublicationDate.Text = "{{IN CODE}}";
            // 
            // labelEpisodeDescription
            // 
            this.labelEpisodeDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEpisodeDescription.Location = new System.Drawing.Point(459, 61);
            this.labelEpisodeDescription.Name = "labelEpisodeDescription";
            this.labelEpisodeDescription.Size = new System.Drawing.Size(311, 51);
            this.labelEpisodeDescription.TabIndex = 12;
            this.labelEpisodeDescription.Text = "{{IN CODE}}";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(785, 381);
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
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxEpisodes);
            this.Controls.Add(this.listBoxPodcasts);
            this.Name = "MainForm";
            this.Text = "My Podcasts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnMainFormClosed);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPodcasts;
        private System.Windows.Forms.ListBox listBoxEpisodes;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.TextBox textBoxNotes;
        private System.Windows.Forms.Label labelMyTags;
        private System.Windows.Forms.Label labelMyNotes;
        private System.Windows.Forms.NumericUpDown numericUpDownRating;
        private System.Windows.Forms.Label labelMyRating;
        private System.Windows.Forms.CheckBox checkBoxIsFavorite;
        private System.Windows.Forms.Label labelEpisodeTitle;
        private System.Windows.Forms.Label labelPublicationDate;
        private System.Windows.Forms.Label labelEpisodeDescription;
    }
}

