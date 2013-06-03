using System;

class OddOrEven
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        if (number % 2 == 0)
        {
            Console.WriteLine("{0} is even", number);
        }
        else
        {
            Console.WriteLine("{0} is odd", number);
        }
    }
}

