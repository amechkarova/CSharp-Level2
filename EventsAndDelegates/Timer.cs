using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class Timer
    {
        // Define a delegate that takes an int and returns an int
        public delegate int IncreaseNumber(int number);

        // Define an event based on the delegate
        public event IncreaseNumber TimerStarted;

        private readonly int _milliseconds;
        private bool _isRunning;
        private int _currentValue;

        public Timer(int initialValue, int seconds)
        {
            _currentValue = initialValue;
            _milliseconds = seconds * 1000;
        }

        // Method for starting the timer
        public void startTimer()
        {
            _isRunning = true;
            run();
        }

        private void run()
        {
            while (_isRunning)
            {
                Thread.Sleep(_milliseconds);
                _currentValue = TimerStarted.Invoke(_currentValue);  
            }

        }

        // Subscriber method
        public int increase(int number)
        {
            Console.WriteLine("The number is increased by 1.");
            return number + 1;
        }

        public int multiply(int number)
        {
            Console.WriteLine("The number is multiplied by 2.");
            return number * 2;
        }
    }
}
