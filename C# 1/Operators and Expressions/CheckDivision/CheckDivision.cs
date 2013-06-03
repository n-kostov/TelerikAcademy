using System;

class CheckDivision
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        if (number % 7 == 0 && number % 5 == 0)
        {
            Console.WriteLine("{0} can be divided by 7 and 5", number);
        }
        else
        {
            Console.WriteLine("{0} cannot be divided by 7 and 5", number);
        }
    }
}

