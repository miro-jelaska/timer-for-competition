using System.Windows;
using Competition.Timer.StateDomain.Time;
using Competition.Timer.StateDomain;

namespace Competition.Timer.StateDomain.States
{
    public class PresentationRunning : TimerState
    {
        public PresentationRunning(MainWindow mainWindow, TimeProvider timeProvider): base(mainWindow, timeProvider, State.PresentationRunning){ }

        protected override void UpdateMainWindow()
        {
            MainWindow.TitleLabel.Visibility = Visibility.Visible;

            MainWindow.PreparationButton.Visibility = Visibility.Collapsed;
            MainWindow.PresentationButton.Visibility = Visibility.Collapsed;
            MainWindow.QuestionsButton.Visibility = Visibility.Collapsed;

            MainWindow.PauseButton.Visibility = Visibility.Visible;
            MainWindow.ContinueButton.Visibility = Visibility.Collapsed;
            MainWindow.ResetButton.Visibility = Visibility.Collapsed;
            MainWindow.FinishButton.Visibility = Visibility.Visible;

            MainWindow.TitleLabel.Content = "Prezentacija u tijeku...";
        }
    }
}
