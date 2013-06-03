using System.Text.RegularExpressions;
using System;

class ExtractEmailAddresses
{
    static void Main()
    {
        string text = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com.";
        string pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        Regex regex = new Regex(pattern);
        foreach (var item in regex.Matches(text))
        {
            Console.WriteLine(item);
        }
    }
}

