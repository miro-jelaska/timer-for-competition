using System.Windows;
using Competition.Timer.StateDomain.Time;
using Competition.Timer.StateDomain;

namespace Competition.Timer.StateDomain.States
{
    public class QuestionsRunning : TimerState
    {
        public QuestionsRunning(MainWindow mainWindow, TimeProvider timeProvider): base(mainWindow, timeProvider, State.QuestionsRunning){}
        
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

            MainWindow.TitleLabel.Content = "Pitanja i odgovori u tijeku...";
        }
    }
}
