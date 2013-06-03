using System;

class NumbersOfWorkdays
{

    static int CalculateWorkdays(DateTime now, DateTime later, DateTime[] holidays)
    {
        // now cannot be after later
        if (DateTime.Compare(now, later) != -1)
        {
            return 0;
        }
        else
        {
            DateTime temp = now;
            int days = 0;
            while (temp.Year != later.Year)
            {
                if (DateTime.IsLeapYear(temp.Year))
                {
                    days += 366 - temp.DayOfYear;
                }
                else
                {
                    days += 365 - temp.DayOfYear;
                }
                if (temp.Year == now.Year)
                {
                    temp = temp.AddDays(++days);
                }
                else
                {
                    temp = temp.AddYears(1);
                }
            }
            days += later.DayOfYear - temp.DayOfYear; // days between now and later

            int weekends = days / 7 * 2;
            temp = now;
            // in the last week of later there could be more weekends
            for (int i = 0; i < days % 7; i++)
            {
                temp = temp.AddDays(1);
                if (temp.DayOfWeek == DayOfWeek.Saturday || temp.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekends++;
                }

            }

            // checks if the holiday is between the first and the second date and if it's not weekend
            for (int i = 0; i < holidays.Length; i++)
            {
                if (DateTime.Compare(now, holidays[i]) != 1 && DateTime.Compare(later, holidays[i]) >= 0 && holidays[i].DayOfWeek != DayOfWeek.Saturday && holidays[i].DayOfWeek != DayOfWeek.Sunday)
                {
                    days--;
                }
            }
            return days - weekends;
        }
    }

    static void Main()
    {
        DateTime[] holidays = { new DateTime(2014, 1, 24) };
        Console.WriteLine(CalculateWorkdays(DateTime.Now, new DateTime(2014, 1, 24), holidays));
    }
}

