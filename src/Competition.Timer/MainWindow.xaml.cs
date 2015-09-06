using System;
using System.Windows;
using System.Windows.Threading;
using Competition.Timer.SoundNotifications;
using Competition.Timer.StateDomain;
using Competition.Timer.StateDomain.States;

namespace Competition.Timer
{
    public partial class MainWindow
    {
        public WindowVModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new WindowVModel();
            DataContext = this.ViewModel;

            DispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            DispatcherTimer.Tick += _UpdateTimer;

            CurrenState = Idle.Create(this);
        }

        public DispatcherTimer DispatcherTimer { get; } = new DispatcherTimer();
        public TimerState CurrenState { get; set; }
        private SoundNotificationService SoundNotificationService { get; } = new SoundNotificationService();


        private void _UpdateTimer(object sender, EventArgs e)
        {
            SoundNotificationService.TimeChanged(CurrenState.Timer);
            if (CurrenState.Timer.TotalSeconds <= 0)
            {
                CurrenState.SetNextState(Command.TimeExpired);
            }
            else
            {
                CurrenState.Timer = this.CurrenState.Timer.Add(TimeSpan.FromSeconds(-1));
                ViewModel.Time = TimespanToString(this.CurrenState.Timer);
            }
        }
        private string TimespanToString(TimeSpan timeSpan)
        {
            return $"{((int)timeSpan.TotalSeconds) / 60}:{((int)timeSpan.TotalSeconds) % 60}";
        }

        private void PreparationButton_Click(object sender, RoutedEventArgs e)
        {
            CurrenState.SetNextState(Command.StartPreparation);
        }

        private void PresentationButton_Click(object sender, RoutedEventArgs e)
        {
            CurrenState.SetNextState(Command.StartPresentation);
        }

        private void QuestionsButton_Click(object sender, RoutedEventArgs e)
        {
            CurrenState.SetNextState(Command.StartQuestions);
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            CurrenState.SetNextState(Command.Pause);
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            CurrenState.SetNextState(Command.Continue);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            CurrenState.SetNextState(Command.Reset);
        }

        private void FinishedButton_Click(object sender, RoutedEventArgs e)
        {
            CurrenState.SetNextState(Command.FinishedEarlier);
        }
    }
}
