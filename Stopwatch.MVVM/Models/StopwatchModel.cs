using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Stopwatch.Models
{
    public class StopwatchModel
    {
        private readonly System.Diagnostics.Stopwatch _stopwatch;
        public event EventHandler<string> ElapsedTimeChanged;

        public StopwatchModel()
        {
            _stopwatch = new ();
        }

        public void Start()
        {
            _stopwatch.Start();
            Task.Run(() =>
            {
                while (_stopwatch.IsRunning)
                {
                    ElapsedTimeChanged?.Invoke(this, ElapsedTime);
                }
            });
        }

        public void Stop()
        {
            _stopwatch.Stop();
        }

        public void Reset()
        {
            _stopwatch.Reset();
            ElapsedTimeChanged?.Invoke(this, ElapsedTime);
        }

        public TimeSpan Elapsed => _stopwatch.Elapsed;

        public bool IsRunning => _stopwatch.IsRunning;

        public string ElapsedTime => _stopwatch.Elapsed.ToString("hh\\:mm\\:ss\\.fff");

        public void Lap()
        {
            if (!_stopwatch.IsRunning)
                return;
            Laps.Add(new Lap(Elapsed, Laps.Count + 1));
        }

        public void Clear()
        {
            if (_stopwatch.IsRunning)
                return;
            Laps.Clear();
        }

        public ObservableCollection<Lap> Laps { get; } = new ObservableCollection<Lap>();
    }

    public class Lap
    {
        public Lap(TimeSpan time, int number)
        {
            LapTime = time.ToString("hh\\:mm\\:ss\\.fff");
            LapNumber = number;
        }
        public string LapTime { get; }
        public int LapNumber { get; }
    }
}