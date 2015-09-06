using System;

namespace Competition.Timer.SoundNotifications
{
    public class SoundNotificationService
    {
        private AudioPlayer AudioPlayer { get; } = new AudioPlayer();

        public void TimeChanged(TimeSpan currentTime)
        {
            if (currentTime == SoundNotificationConfig.AlmostTimeUp.TriggerTime)
                AudioPlayer.Play(SoundNotificationConfig.AlmostTimeUp.NotificationSoundUri);
            if(currentTime == SoundNotificationConfig.TimeUp.TriggerTime)
                AudioPlayer.Play(SoundNotificationConfig.TimeUp.NotificationSoundUri);
        }
    }
}
