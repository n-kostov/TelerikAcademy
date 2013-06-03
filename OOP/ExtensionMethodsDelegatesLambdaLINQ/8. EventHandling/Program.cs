using System;

//  8.* Read in MSDN about the keyword event in C# and how to publish events.
//  Re-implement the above using .NET events and following the best practices.

namespace _8.EventHandling
{
    class Program
    {
        public static void PrintCurrentDate(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }

        public static void PrintOne(object sender, EventArgs e)
        {
            Console.WriteLine(1);
        }

        static void Main(string[] args)
        {
            Timer timer = new Timer(2000);
            timer.Tick += new IntervalElapsedEventHandler(PrintCurrentDate);
            timer.Tick += new IntervalElapsedEventHandler(PrintOne);
        }
    }
}
