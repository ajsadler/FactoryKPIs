using System.Timers;
using Microsoft.AspNetCore.Components;

namespace FactoryKPIs.Services
{
    public class NavigationCycleService(NavigationManager navigation) : IDisposable
    {
        private readonly NavigationManager _navigation = navigation;
        private System.Timers.Timer? _timer;
        private string[] _urls = [];
        private int _currentIndex;
        private int _delayTime;

        public void StartCycle(string[] urls, int delayTime)
        {
            StopCycle(); // stop any existing cycle
            _urls = urls;
            _delayTime = delayTime;
            _currentIndex = 0;

            // Immediately navigate to the first URL
            _navigation.NavigateTo(_urls[_currentIndex]);

            // Create and start the timer
            _timer = new System.Timers.Timer(delayTime);
            _timer.Elapsed += TimerElapsed;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void TimerElapsed(object? sender, ElapsedEventArgs e)
        {
            // Cycle to next URL
            _currentIndex = (_currentIndex + 1) % _urls.Length;
            // Navigate to the next URL
            _navigation.NavigateTo(_urls[_currentIndex]);
        }

        public void StopCycle()
        {
            if (_timer is not null)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }
        }

        public void Dispose() => StopCycle();
    }
}