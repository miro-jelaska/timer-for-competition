using System;
using Competition.Timer;
using Competition.Timer.StateDomain;
using Competition.Timer.StateDomain.States;
using Competition.Timer.StateDomain.Time;
using Competition.Timer.StateDomain.Time;
using FluentAssertions;

namespace Competition.Timer.StateDomain
{
    public abstract class TimerState
    {
        protected TimerState(MainWindow mainWindow, TimeProvider timeProvider, State state)
        {
            mainWindow.Should().NotBeNull();
            timeProvider.Should().NotBeNull();

            this.MainWindow = mainWindow;
            this.Timer = timeProvider.GetTime();
            this.State = state;
            this.UpdateMainWindow();
        }

        public readonly State State;
        public TimeSpan Timer { get; set; }
        protected MainWindow MainWindow { get; set; }
        protected abstract void UpdateMainWindow();

        public void SetNextState(Command newCommand)
        {
            newCommand.Should().NotBeNull();

            var nextStateAndTimeTransferType = Competition.Timer.StateDomain.Rules.Transition.GetNextStateAndTimeTransferType(State, newCommand);
            var nextState = nextStateAndTimeTransferType.Item1;
            var timeTransferType = nextStateAndTimeTransferType.Item2;

            var timeProvider =
                nextStateAndTimeTransferType.Item2 == TimeTransferType.None
                    ? new TimeProvider(nextState)
                    : new TimeProvider(nextState, Timer, timeTransferType);

            MainWindow.CurrenState = CreateTimerState(nextState, timeProvider);

            if (Competition.Timer.StateDomain.Rules.Timer.IsTimerNotRunningForState(nextState))
                MainWindow.DispatcherTimer.Stop();
            else
                MainWindow.DispatcherTimer.Start();
        }
        private TimerState CreateTimerState(State nextState, TimeProvider timeProvider)
        {
            timeProvider.Should().NotBeNull();
            (State != nextState).Should().BeTrue();

            switch (nextState)
            {
                case State.Idle:                return new Idle               (MainWindow, timeProvider);
                case State.PreparationRunning:  return new PreparationRunning (MainWindow, timeProvider);
                case State.PreparationPaused:   return new PreparationPaused  (MainWindow, timeProvider);
                case State.PresentationRunning: return new PresentationRunning(MainWindow, timeProvider);
                case State.PresentationPaused:  return new PresentationPaused (MainWindow, timeProvider);
                case State.QuestionsRunning:    return new QuestionsRunning   (MainWindow, timeProvider);
                case State.QuestionsPaused:     return new QuestionsPaused    (MainWindow, timeProvider);
                default: throw new ArgumentException("Requested state doesn't exist.");
            }
        }
    }
}
