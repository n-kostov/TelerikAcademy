using System;
using System.Text.RegularExpressions;

class ExtractSenteces
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string[] sentences = text.Split('.');
        string pattern = @"\bin\b";
        Regex regex = new Regex(pattern);
        for (int i = 0; i < sentences.Length; i++)
        {
            if (regex.IsMatch(sentences[i]))
            {
                Console.WriteLine(sentences[i].Trim() + ".");
            }
        }
    }
}

