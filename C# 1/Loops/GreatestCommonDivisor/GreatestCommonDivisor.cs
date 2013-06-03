using System;

    class GreatestCommonDivisor
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                } 
                else
                {
                    b -= a;
                }
            }
            Console.WriteLine(a);
        }
    }

