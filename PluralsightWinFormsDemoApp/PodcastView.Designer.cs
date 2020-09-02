namespace PluralsightWinFormsDemoApp
{
    partial class PodcastView
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
            this.labelPodcastTitle = new System.Windows.Forms.Label();
            this.labelEpisodeCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPodcastTitle
            // 
            this.labelPodcastTitle.AutoSize = true;
            this.labelPodcastTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPodcastTitle.Location = new System.Drawing.Point(4, 4);
            this.labelPodcastTitle.Name = "labelPodcastTitle";
            this.labelPodcastTitle.Size = new System.Drawing.Size(158, 24);
            this.labelPodcastTitle.TabIndex = 0;
            this.labelPodcastTitle.Text = "{{Podcast Title}}";
            // 
            // labelEpisodeCount
            // 
            this.labelEpisodeCount.AutoSize = true;
            this.labelEpisodeCount.Location = new System.Drawing.Point(8, 32);
            this.labelEpisodeCount.Name = "labelEpisodeCount";
            this.labelEpisodeCount.Size = new System.Drawing.Size(89, 13);
            this.labelEpisodeCount.TabIndex = 1;
            this.labelEpisodeCount.Text = "{{EpisodeCount}}";
            // 
            // PodcastView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelEpisodeCount);
            this.Controls.Add(this.labelPodcastTitle);
            this.Name = "PodcastView";
            this.Size = new System.Drawing.Size(227, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPodcastTitle;
        private System.Windows.Forms.Label labelEpisodeCount;
    }
}
