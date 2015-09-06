using System;
using FluentAssertions;

namespace Competition.Timer.StateDomain.Time
{
    public class TimeProvider
    {
        public TimeProvider(State state, TimeSpan timeForTransfer, TimeTransferType transferType)
        {
            (timeForTransfer > TimeSpan.Zero).Should().BeTrue();

            switch (transferType)
            {
                case TimeTransferType.Assignment:
                    _time = timeForTransfer;
                    break;
                case TimeTransferType.Bonus:
                    _time = TimeConfig.GetDefaultStartTimeForState(state) + timeForTransfer;
                    break;
            }
        }

        public TimeProvider(State state)
        {
            _time = TimeConfig.GetDefaultStartTimeForState(state);
        }

        public TimeSpan GetTime()
        {
            return _time;
        }
        private readonly TimeSpan _time;
    }
}
