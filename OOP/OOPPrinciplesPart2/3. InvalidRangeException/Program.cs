using System;

//  3.Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. 
//  It should hold error message and a range definition [start … end]. Write a sample application that demonstrates 
//  the InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and 
//  dates in the range [1.1.1980 … 31.12.2013].

class Program
{
    static void Main(string[] args)
    {
        int start = 1;
        int end = 100;
        DateTime startDate = new DateTime(1980, 1, 1);
        DateTime endDate = new DateTime(2013, 12, 31);

        try
        {
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            if (number < start || number > end)
            {
                throw new InvalidRangeException<int>("The integer cannot be outside of the permissive range!", start, end);
            }
        }
        catch (InvalidRangeException<int> ex)
        {
            Console.WriteLine("{0}\nRange: [{1},{2}]", ex.Message, ex.Start, ex.End);
        }

        try
        {
            Console.Write("Date: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            if (date < startDate || date > endDate)
            {
                throw new InvalidRangeException<DateTime>("The date cannot be outside of the permissive range!", startDate, endDate);
            }
        }
        catch (InvalidRangeException<DateTime> ex)
        {
            Console.WriteLine("{0}\nRange: [{1} - {2}]", ex.Message, ex.Start.ToString("dd.MM.yyyy"), ex.End.ToString("dd.MM.yyyy"));
        }
    }
}
