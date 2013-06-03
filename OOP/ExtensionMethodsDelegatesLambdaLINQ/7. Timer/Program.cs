using System;

//  7.Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace _7.Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer myTimer = new Timer(3000, delegate { Console.WriteLine(DateTime.Now); });

            Timer myTimer2 = new Timer(2000, delegate { Console.WriteLine(1); });

            int i = 0;
            while (true)
            {
                if (i == int.MaxValue || i == int.MinValue)
                {
                    Console.WriteLine(i);
                }
                i++;
            }


        }
    }
}
