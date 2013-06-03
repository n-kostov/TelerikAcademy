using System.Text.RegularExpressions;
using System;

class ExtractPalindromes
{
    static void Main()
    {
        string text = "ABBA is exe in music lamal and beeb dieid was done";
        Regex regex = new Regex(@"\b\w+\b");
        foreach (var item in regex.Matches(text))
        {
            bool isPAlindrome = true;
            for (int i = 0; i < item.ToString().Length; i++)
            {
                if (item.ToString()[i] != item.ToString()[item.ToString().Length - 1 - i])
                {
                    isPAlindrome = false;
                    break;
                }
            }
            if (isPAlindrome)
            {
                Console.WriteLine(item);
            } 
        }
    }
}

