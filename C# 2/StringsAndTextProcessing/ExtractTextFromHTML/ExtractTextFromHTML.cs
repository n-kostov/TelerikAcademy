using System;
using System.Text.RegularExpressions;

class ExtractTextFromHTML
{
    static void Main()
    {
        string text = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">Telerik Academy</a>aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";

        int indexLeft = text.IndexOf('>');
        int indexRight = text.IndexOf('<', indexLeft + 1);
        while (indexLeft != -1 && indexRight != -1)
        {
            if (indexLeft + 1 < indexRight)
            {
                Console.WriteLine(text.Substring(indexLeft + 1, indexRight - indexLeft - 1));
            }
            indexLeft = text.IndexOf('>', indexLeft + 1);
            indexRight = text.IndexOf('<', indexLeft);
        }
    }
}

