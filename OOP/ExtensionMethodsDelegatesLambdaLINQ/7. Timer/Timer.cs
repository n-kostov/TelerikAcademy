using System.Threading;
using System;

namespace _7.Timer
{
    public delegate void TimeElapsedDelegate();

    public class Timer
    {
        private int interval;
        private TimeElapsedDelegate function;

        public Timer(int interval, TimeElapsedDelegate func)
        {
            this.interval = interval;
            this.function = func;
            Thread timerThread = new Thread(new ThreadStart(() => this.Execute()));
            timerThread.Start();
        }

        public int Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The interval cannot be less than 0");
                }

                this.interval = value;
            }
        }

        public void Execute()
        {
            while (true)
            {
                function();
                Thread.Sleep(interval);
            }
        }
    }
}
