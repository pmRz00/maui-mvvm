using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Stopwatch.Models;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Stopwatch.ViewModels
{
    public class StopwatchViewModel : BindableObject
    {
        public static StopwatchViewModel Instance { get; } = new StopwatchViewModel();
        private StopwatchModel _stopwatchModel;

        public StopwatchViewModel()
        {
            _stopwatchModel = new StopwatchModel();
            _stopwatchModel.ElapsedTimeChanged += (sender, elapsedTime) =>
            {
                ElapsedTime = elapsedTime;
                Laps = new ObservableCollection<Lap>(_stopwatchModel.Laps);
            };
            StartCommand = new Command(() =>
            {
                if (_stopwatchModel.IsRunning)
                {
                    _stopwatchModel.Stop();
                    ButtonStartText = "Start";
                }
                else
                {
                    _stopwatchModel.Start();
                    ButtonStartText = "Stop";
                }
            });

            LapCommand = new Command(() =>
            {
                if (_stopwatchModel.IsRunning)
                {
                    _stopwatchModel.Lap();
                }
                else
                {
                    _stopwatchModel.Clear();
                }
            });
        }

        public ICommand StartCommand { get; }
        public ICommand LapCommand { get; }

        public string ElapsedTime { get; private set; }
        public string ButtonStartText { get; private set; } = "Start";
        public string ButtonLapText { get; private set; } = "Lap";
        public ObservableCollection<Lap> Laps { get; private set; } = new ObservableCollection<Lap>();
    }
}
