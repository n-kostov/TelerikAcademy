using System;

class SubstringOccurenceInText
{
    static void Main()
    {
        string text = "We are living in an yellow submarine.We don't have anything else. Inside the submarine is very tight.So we are drinking all the day. We will move out of it in 5 days.";
        int count = 0;
        int index = text.IndexOf("in",StringComparison.InvariantCultureIgnoreCase);
        while (index != -1)
        {
            count++;
            index = text.IndexOf("in", index + 1,StringComparison.InvariantCultureIgnoreCase);
        }
        Console.WriteLine("'In' can be found {0} times in the text", count);
    }
}

