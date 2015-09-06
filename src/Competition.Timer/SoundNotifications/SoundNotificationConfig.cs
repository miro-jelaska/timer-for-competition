using System;
using System.IO;

namespace Competition.Timer.SoundNotifications
{
    public static class SoundNotificationConfig
    {
        private static readonly Uri ResourcesFolderUri = new Uri(
            Path.Combine(
                path1: Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName), 
                path2: "Resources/"));

        public class AlmostTimeUp
        {
            public static Uri NotificationSoundUri => new Uri(ResourcesFolderUri, "almost-time-up.mp3");
            public static TimeSpan TriggerTime => TimeSpan.FromSeconds(15);
        }

        public class TimeUp
        {
            public static Uri NotificationSoundUri => new Uri(ResourcesFolderUri, "time-up.mp3");
            public static TimeSpan TriggerTime => TimeSpan.Zero;
        }
    }
}
