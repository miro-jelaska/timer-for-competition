using System;
using System.Collections.Generic;
using Competition.Timer.Properties;

namespace Competition.Timer.StateDomain.Time
{
    public static class TimeConfig
    {
        private static readonly Dictionary<State, TimeSpan> DefaultStartTimeForState = new Dictionary<State, TimeSpan>
        {
            {State.PreparationRunning, TimeSpan.FromMinutes(Settings.Default.PreparationTime)},
            {State.PresentationRunning, TimeSpan.FromMinutes(Settings.Default.PresentationTime)},
            {State.QuestionsRunning, TimeSpan.FromMinutes(Settings.Default.QuestionsTime)}
        };

        public static TimeSpan GetDefaultStartTimeForState(State state)
        {
            return
                DefaultStartTimeForState.ContainsKey(state)
                    ? DefaultStartTimeForState[state]
                    : TimeSpan.Zero;
        }
    }
}
