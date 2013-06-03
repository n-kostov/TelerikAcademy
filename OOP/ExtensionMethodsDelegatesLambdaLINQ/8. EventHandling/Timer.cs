using System;
using System.Threading;

namespace _8.EventHandling
{

    public delegate void IntervalElapsedEventHandler(object sender, EventArgs args);

    public class Timer
    {
        private int interval;

        public event IntervalElapsedEventHandler Tick;

        public int Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentOutOfRangeException("The interval cannot be less than 0");
                }

                this.interval = value;
            }
        }

        public Timer(int interval)
        {
            this.interval = interval;
            Thread timerThread = new Thread(new ThreadStart(() => this.Execute()));
            timerThread.Start();
        }

        protected virtual void OnTick(EventArgs args)
        {
            IntervalElapsedEventHandler handler = Tick;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        public void Execute()
        {
            Thread newThread = new Thread(delegate()
            {
                while (true)
                {
                    OnTick(null);
                    Thread.Sleep(interval);
                }
            });
            newThread.Start();
        }

    }
}
