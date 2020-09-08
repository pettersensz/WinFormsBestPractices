using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<float[]> LoadPeaksAsync()
        {
            return Task.Run(() =>
            {
                var peaks = new List<float>();
                using (var reader = new MediaFoundationReader(_currentEpisode.AudioFile))
                {
                    var sampleProvider = reader.ToSampleProvider();
                    var sampleBuffer = new float[reader.WaveFormat.SampleRate * reader.WaveFormat.Channels];
                    int read;
                    do
                    {
                        read = sampleProvider.Read(sampleBuffer, 0, sampleBuffer.Length);
                        if (read > 0)
                        {
                            var max = sampleBuffer.Take(read).Select(Math.Abs).Max();
                            peaks.Add(max);
                        }
                    } while (read > 0);

                    return peaks.ToArray();
                }
            });
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
