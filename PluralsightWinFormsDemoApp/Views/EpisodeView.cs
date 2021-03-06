﻿using PluralsightWinFormsDemoApp.Resources;
using System;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Views
{
    public partial class EpisodeView : UserControl, IEpisodeView
    {
        public EpisodeView()
        {
            InitializeComponent();
            toolTipEpisodeView.SetToolTip(textBoxTags, "Enter tags for this podcast, comma separated.");
            toolTipEpisodeView.SetToolTip(buttonPlay, "Play the podcast in windows media player.");
        }

        void TextBoxTags_HelpRequested(object sender, HelpEventArgs hlpEvent)
        {
            MessageBox.Show(TextResources.TagsHelp);
        }

        public string Description
        {
            get => labelEpisodeDescription.Text;
            set => labelEpisodeDescription.Text = value;
        }

        public string Title
        {
            get => labelEpisodeTitle.Text;
            set => labelEpisodeTitle.Text = value;
        }

        public string PublicationDate
        {
            get => labelPublicationDate.Text;
            set => labelPublicationDate.Text = value;
        }

        public bool EpisodeIsFavorite
        {
            get => checkBoxIsFavorite.Checked;
            set => checkBoxIsFavorite.Checked = value;
        }

        public int Rating
        {
            get => (int)numericUpDownRating.Value;
            set => numericUpDownRating.Value = value;
        }

        public int PositionInSeconds
        {
            get => waveFormViewer1.PositionInSeconds;
            set => waveFormViewer1.PositionInSeconds = value;
        }

        public string Notes
        {
            get => textBoxNotes.Text;
            set => textBoxNotes.Text = value;
        }

        public string Tags
        {
            get => textBoxTags.Text;
            set => textBoxTags.Text = value;
        }

        public event EventHandler PlayClicked
        {
            add => buttonPlay.Click += value;
            remove => buttonPlay.Click -= value;
        }
        public event EventHandler StopClicked
        {
            add => buttonStop.Click += value;
            remove => buttonStop.Click -= value;
        }

        public void SetPeaks(float[] peaks)
        {
            waveFormViewer1.SetPeaks(peaks);
        }

        public event EventHandler PositionChanged
        {
            add => waveFormViewer1.PositionChanged += value;
            remove => waveFormViewer1.PositionChanged -= value;
        }
    }

    public interface IEpisodeView
    {
        string Description { set; }
        string Title { set; }
        string PublicationDate { set; }
        bool EpisodeIsFavorite { get; set; }
        int Rating { get; set; }
        string Notes { get; set; }
        string Tags { get; set; }

        int PositionInSeconds { get; set; }

        event EventHandler PositionChanged;

        event EventHandler PlayClicked;
        event EventHandler StopClicked;

        void SetPeaks(float[] peaks);
    }
}
