using System.Collections.Generic;
using System.Linq;

namespace Competition.Timer.StateDomain.Rules
{
    public static class Timer
    {
        private static readonly IReadOnlyCollection<State> StatesWhereTimerIsNotRunning = new List<State>
        {
            State.Idle,
            State.PreparationPaused,
            State.PresentationPaused,
            State.QuestionsPaused
        };

        public static bool IsTimerNotRunningForState(State state)
        {
            return StatesWhereTimerIsNotRunning.Contains(state);
        }
    }
}
