using System;
using System.Text.RegularExpressions;

class ForbiddenWords
{
    static void Main()
    {
        string[] words = { "PHP", "CLR", "Microsoft" };
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        for (int i = 0; i < words.Length; i++)
        {
            string pattern = string.Format(@"\b{0}\b", words[i]);
            Regex regex = new Regex(pattern);
            text = regex.Replace(text, new string('*', words[i].Length));
        }
        Console.WriteLine(text);
    }
}

