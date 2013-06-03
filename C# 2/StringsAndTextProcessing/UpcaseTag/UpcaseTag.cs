using System;
using System.Text.RegularExpressions;

class UpcaseTag
{
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        int indexLeft = text.IndexOf("<upcase>");
        int indexRight = text.IndexOf("</upcase", indexLeft);
        while (indexLeft != -1 && indexRight != -1)
        {
            string sub = text.Substring(indexLeft + 8, indexRight - indexLeft - 8);
            string pattern = string.Format(@"<upcase>{0}</upcase>", sub);
            Regex regex = new Regex(pattern);
            text = regex.Replace(text, sub.ToUpper());
            indexLeft = text.IndexOf("<upcase>", indexLeft + 1);
            if (indexLeft != -1)
            {
                indexRight = text.IndexOf("</upcase", indexLeft);
            }
        }
        Console.WriteLine(text);
    }
}

