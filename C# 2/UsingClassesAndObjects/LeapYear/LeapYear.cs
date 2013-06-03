using System;

class LeapYear
{
    static void Main()
    {
        Console.Write("year = ");
        short year = short.Parse(Console.ReadLine());
        if (DateTime.IsLeapYear(year))
        {
            Console.WriteLine("{0} is a leap year", year);
        }
        else
        {
            Console.WriteLine("{0} is a regular year", year);
        }
    }
}


