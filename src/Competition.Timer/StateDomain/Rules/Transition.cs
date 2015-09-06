using System;
using System.Collections.Generic;
using Competition.Timer.StateDomain.Time;

namespace Competition.Timer.StateDomain.Rules
{
    public static class Transition
    {
        private static readonly Dictionary<Tuple<State, Command>, Tuple<State, TimeTransferType>> StateAndCommandToNextStateAndTimeTransferType = new Dictionary<Tuple<State, Command>, Tuple<State,TimeTransferType>>
        {
            {Tuple.Create(State.Idle, Command.StartPreparation),  Tuple.Create(State.PreparationRunning, TimeTransferType.None)},
            {Tuple.Create(State.Idle, Command.StartPresentation), Tuple.Create(State.PresentationRunning, TimeTransferType.None)},
            {Tuple.Create(State.Idle, Command.StartQuestions),    Tuple.Create(State.QuestionsRunning, TimeTransferType.None)},

            {Tuple.Create(State.PreparationRunning, Command.Pause),           Tuple.Create(State.PreparationPaused, TimeTransferType.Assignment)},
            {Tuple.Create(State.PreparationRunning, Command.FinishedEarlier), Tuple.Create(State.PresentationRunning, TimeTransferType.Bonus)},
            {Tuple.Create(State.PreparationRunning, Command.TimeExpired),     Tuple.Create(State.PresentationRunning, TimeTransferType.None)},

            {Tuple.Create(State.PreparationPaused, Command.Continue), Tuple.Create(State.PreparationRunning, TimeTransferType.Assignment)},
            {Tuple.Create(State.PreparationPaused, Command.Reset),    Tuple.Create(State.Idle, TimeTransferType.None)},

            {Tuple.Create(State.PresentationRunning, Command.Pause),           Tuple.Create(State.PresentationPaused, TimeTransferType.Assignment)},
            {Tuple.Create(State.PresentationRunning, Command.FinishedEarlier), Tuple.Create(State.QuestionsRunning, TimeTransferType.Bonus)},
            {Tuple.Create(State.PresentationRunning, Command.TimeExpired),     Tuple.Create(State.QuestionsRunning, TimeTransferType.None)},

            {Tuple.Create(State.PresentationPaused, Command.Continue), Tuple.Create(State.PresentationRunning, TimeTransferType.Assignment)},
            {Tuple.Create(State.PresentationPaused, Command.Reset),    Tuple.Create(State.Idle, TimeTransferType.None)},

            {Tuple.Create(State.QuestionsRunning, Command.Pause),           Tuple.Create(State.QuestionsPaused, TimeTransferType.Assignment)},
            {Tuple.Create(State.QuestionsRunning, Command.FinishedEarlier), Tuple.Create(State.PreparationRunning, TimeTransferType.None)},
            {Tuple.Create(State.QuestionsRunning, Command.TimeExpired),     Tuple.Create(State.PreparationRunning, TimeTransferType.None)},

            {Tuple.Create(State.QuestionsPaused, Command.Continue), Tuple.Create(State.QuestionsRunning, TimeTransferType.Assignment)},
            {Tuple.Create(State.QuestionsPaused, Command.Reset),    Tuple.Create(State.Idle, TimeTransferType.None)},
        };
        public static Tuple<State, TimeTransferType> GetNextStateAndTimeTransferType(State currentState, Command command)
        {
            var currentStateAndCommand = Tuple.Create(currentState, command);

            return StateAndCommandToNextStateAndTimeTransferType[currentStateAndCommand];
        }
    }
}
