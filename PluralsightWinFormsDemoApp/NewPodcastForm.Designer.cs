namespace PluralsightWinFormsDemoApp
{
    partial class NewPodcastForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxFeedUrl = new System.Windows.Forms.TextBox();
            this.labelFeedURL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(197, 63);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxFeedUrl
            // 
            this.textBoxFeedUrl.Location = new System.Drawing.Point(78, 25);
            this.textBoxFeedUrl.Name = "textBoxFeedUrl";
            this.textBoxFeedUrl.Size = new System.Drawing.Size(194, 20);
            this.textBoxFeedUrl.TabIndex = 1;
            // 
            // labelFeedURL
            // 
            this.labelFeedURL.AutoSize = true;
            this.labelFeedURL.Location = new System.Drawing.Point(13, 28);
            this.labelFeedURL.Name = "labelFeedURL";
            this.labelFeedURL.Size = new System.Drawing.Size(59, 13);
            this.labelFeedURL.TabIndex = 2;
            this.labelFeedURL.Text = "Feed URL:";
            // 
            // NewPodcastForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 110);
            this.Controls.Add(this.labelFeedURL);
            this.Controls.Add(this.textBoxFeedUrl);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NewPodcastForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add a New Podcast";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxFeedUrl;
        private System.Windows.Forms.Label labelFeedURL;
    }
}