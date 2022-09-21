using System;

namespace myApp
{
    class Stopwatch
    {
        private DateTime _start;
        private DateTime _stop;

        private TimeSpan _finally;
        private bool _running;
        private List<TimeSpan> _history = new List<TimeSpan>();
        public void Restart()
        {
            if (!_running)
            {
                _running = true;
                _start = DateTime.Now;
            }
        }
        public TimeSpan Stop()
        {
            if (_running)
            {
                _stop = DateTime.Now;
                _running = false;
                _finally = _stop - _start;
            }

            _history.Add(_finally);
            return (_finally);
        }
        public void getHistory()
        {
            foreach (object i in _history)
            {
                Console.WriteLine(i);
            }
        }
        public void getLastTime()
        {
            Console.WriteLine(_history[_history.Count - 1]);
        }
    }
}