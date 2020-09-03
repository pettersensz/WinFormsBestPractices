namespace PluralsightWinFormsDemoApp
{
    partial class SubscriptionView
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
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.listBoxEpisodes = new System.Windows.Forms.ListBox();
            this.listBoxPodcasts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.Location = new System.Drawing.Point(84, 324);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 5;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(3, 324);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // listBoxEpisodes
            // 
            this.listBoxEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxEpisodes.FormattingEnabled = true;
            this.listBoxEpisodes.Location = new System.Drawing.Point(213, 3);
            this.listBoxEpisodes.Name = "listBoxEpisodes";
            this.listBoxEpisodes.Size = new System.Drawing.Size(234, 316);
            this.listBoxEpisodes.TabIndex = 4;
            // 
            // listBoxPodcasts
            // 
            this.listBoxPodcasts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPodcasts.FormattingEnabled = true;
            this.listBoxPodcasts.Location = new System.Drawing.Point(3, 3);
            this.listBoxPodcasts.Name = "listBoxPodcasts";
            this.listBoxPodcasts.Size = new System.Drawing.Size(203, 316);
            this.listBoxPodcasts.TabIndex = 3;
            // 
            // SubscriptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxEpisodes);
            this.Controls.Add(this.listBoxPodcasts);
            this.Name = "SubscriptionView";
            this.Size = new System.Drawing.Size(450, 350);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button buttonRemove;
        internal System.Windows.Forms.Button buttonAdd;
        internal System.Windows.Forms.ListBox listBoxEpisodes;
        internal System.Windows.Forms.ListBox listBoxPodcasts;
    }
}
