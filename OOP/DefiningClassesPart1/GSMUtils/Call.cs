using System;

namespace GSMUtils
{
    public class Call
    {
        private DateTime dateAndTime;
        private string phoneNumber;
        private int duration;

        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }

        public DateTime DateAndTime
        {
            get
            {
                return this.dateAndTime;
            }
            set
            {
                this.dateAndTime = value;
            }
        }

        public Call(DateTime date, string phoneNumber, int duration)
        {
            this.dateAndTime = date;
            this.phoneNumber = phoneNumber;
            this.duration = duration;
        }

        public void Print()
        {
            Console.WriteLine("You called at {0} to {1} for {2} secs", dateAndTime, phoneNumber, duration);
        }
    }
}
