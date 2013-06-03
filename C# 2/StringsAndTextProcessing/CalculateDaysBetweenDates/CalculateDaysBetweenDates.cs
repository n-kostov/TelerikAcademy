using System;
using System.Globalization;

class CalculateDaysBetweenDates
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("Enter the first date: ");
        string date1 = Console.ReadLine();
        Console.Write("Enter the second date: ");
        string date2 = Console.ReadLine();
        string[] arguments = date1.Split('.');
        DateTime firstDate = new DateTime(int.Parse(arguments[2]),int.Parse(arguments[1]), int.Parse(arguments[0]));
        arguments = date2.Split('.');
        DateTime secondDate = new DateTime(int.Parse(arguments[2]), int.Parse(arguments[1]), int.Parse(arguments[0]));
        int daysBetween = 0;
        if (DateTime.Compare(firstDate, secondDate) > 0)
        {
            while (DateTime.Compare(secondDate, firstDate) != 0)
            {
                daysBetween++;
                secondDate = secondDate.AddDays(1);
            }
        } 
        else
        {
            while (DateTime.Compare(firstDate, secondDate) != 0)
            {
                daysBetween++;
                firstDate = firstDate.AddDays(1);
            }
        }
        Console.WriteLine("Distance: {0}", daysBetween);
    }
}

