using System.Windows;
using Competition.Timer.StateDomain.Time;

namespace Competition.Timer.StateDomain.States
{
    public class PreparationPaused : TimerState
    {
        public PreparationPaused(MainWindow mainWindow, TimeProvider timeProvider): base(mainWindow, timeProvider, State.PreparationPaused) { }

        protected override void UpdateMainWindow()
        {
            MainWindow.TitleLabel.Visibility = Visibility.Visible;

            MainWindow.PreparationButton.Visibility = Visibility.Collapsed;
            MainWindow.PresentationButton.Visibility = Visibility.Collapsed;
            MainWindow.QuestionsButton.Visibility = Visibility.Collapsed;

            MainWindow.PauseButton.Visibility = Visibility.Collapsed;
            MainWindow.ContinueButton.Visibility = Visibility.Visible;
            MainWindow.ResetButton.Visibility = Visibility.Visible;
            MainWindow.FinishButton.Visibility = Visibility.Collapsed;

            MainWindow.TitleLabel.Content = "Priprema na čekanju!";
        }
    }
}
