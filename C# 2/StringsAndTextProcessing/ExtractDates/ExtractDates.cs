using System.Text.RegularExpressions;
using System;
using System.Globalization;

class ExtractDates
{
    static void Main()
    {
        string text = "12.12.2012 and 01.03.2012 were last year.";
        string pattern = @"\d{2}.\d{2}.\d{4}";
        Regex regex = new Regex(pattern);
        foreach (var item in regex.Matches(text))
        {
            DateTime date = DateTime.ParseExact(item.ToString(),"dd.MM.yyyy", CultureInfo.GetCultureInfo("en-CA"));
            Console.WriteLine(date);
        }
    }
}

