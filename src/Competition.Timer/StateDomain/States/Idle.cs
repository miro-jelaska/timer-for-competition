using System.Windows;
using Competition.Timer.StateDomain.Time;
using Competition.Timer.StateDomain;

namespace Competition.Timer.StateDomain.States
{
    public class Idle : TimerState
    {
        public Idle(MainWindow mainWindow, TimeProvider timeProvider): base(mainWindow, timeProvider, State.Idle) { }

        public static Idle Create(MainWindow mainWindow)
        {
            return new Idle(mainWindow, new TimeProvider(State.Idle));
        }

        protected override void UpdateMainWindow()
        {
            MainWindow.TitleLabel.Visibility = Visibility.Hidden;

            MainWindow.PreparationButton.Visibility = Visibility.Visible;
            MainWindow.PresentationButton.Visibility = Visibility.Visible;
            MainWindow.QuestionsButton.Visibility = Visibility.Visible;

            MainWindow.PauseButton.Visibility = Visibility.Collapsed;
            MainWindow.ResetButton.Visibility = Visibility.Collapsed;
            MainWindow.ContinueButton.Visibility = Visibility.Collapsed;
            MainWindow.FinishButton.Visibility = Visibility.Collapsed;

            MainWindow.TitleLabel.Visibility = Visibility.Hidden;
            MainWindow.ViewModel.Time = "00:00";
        }
    }
}
