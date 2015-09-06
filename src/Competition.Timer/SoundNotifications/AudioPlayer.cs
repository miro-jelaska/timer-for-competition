using System;
using FluentAssertions;
using NAudio.Wave;

namespace Competition.Timer.SoundNotifications
{
    public class AudioPlayer
    {
        private WaveOut WaveOut { get; set; }
        private Mp3FileReader Reader { get; set; }

        public void Play(Uri songUri)
        {
            (songUri != null).Should().BeTrue();
            songUri.IsAbsoluteUri.Should().BeTrue();

            Stop();

            WaveOut = new WaveOut();
            Reader = new Mp3FileReader(songUri.AbsolutePath);
            WaveOut.Init(Reader);
            WaveOut.Play();
        }

        public void Stop()
        {
            if (WaveOut != null)
            {
                WaveOut.Stop();
                WaveOut.Dispose();
                WaveOut = null;
            }
            if (Reader != null)
            {
                Reader.Close();
                Reader.Dispose();
                Reader = null;
            }
        }
    }
}
