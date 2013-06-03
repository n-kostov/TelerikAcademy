using System.Globalization;
using System;

class BulgarianDateFormat
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
        Console.Write("Enter date: ");
        string date = Console.ReadLine();
        string[] args1 = date.Split('.');
        Console.Write("Enter hour: ");
        string hour = Console.ReadLine();
        string[] args2 = hour.Split(':');
        DateTime dateTime = new DateTime(int.Parse(args1[2]), int.Parse(args1[1]), int.Parse(args1[0]), int.Parse(args2[0]), int.Parse(args2[1]), int.Parse(args2[2]));
        dateTime = dateTime.AddMinutes(390);
        Console.WriteLine(dateTime + " " + CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)dateTime.DayOfWeek]);
    }
}

