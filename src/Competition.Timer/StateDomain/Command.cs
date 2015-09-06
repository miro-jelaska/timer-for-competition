namespace Competition.Timer.StateDomain
{
    public enum Command
    {
        StartPreparation,
        StartPresentation,
        StartQuestions,

        Pause,
        Continue,
        Reset,

        FinishedEarlier,
        TimeExpired
    }
}
