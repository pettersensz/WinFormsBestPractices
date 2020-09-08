using NAudio.Wave;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Objects
{
    public class PodcastPlayer : IDisposable, IPodcastPlayer
    {
        private WaveOutEvent _player;
        private Episode _currentEpisode;

        public void UnloadEpisode()
        {
            if (_player != null) _player.Dispose();
            _player = null;
        }

        public void Dispose()
        {
            if (_player != null)
            {
                _player.Dispose();
            }
        }

        public void Play()
        {
            if (_player == null)
            {
                if (_currentEpisode.AudioFile == null)
                {
                    MessageBox.Show("No audio file download provided");
                    Process.Start(_currentEpisode.AudioFile ?? _currentEpisode.Link);
                    return;
                }

                try
                {
                    _player = new WaveOutEvent();
                    _player.Init(new MediaFoundationReader(_currentEpisode.AudioFile));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving podcast audio.");
                    _player = null;
                }
            }

            if (_player != null)
            {
                _player.Play();
            }
        }

        public void Pause()
        {
            _player?.Pause();
        }

        public void Stop()
        {
            _player?.Stop();
        }

        public void LoadEpisode(Episode selectedEpisode)
        {
            _currentEpisode = selectedEpisode;
        }
    }
}
