using System;

class SortListOfWords
{
    static void Main()
    {
        Console.Write("text = ");
        string text = Console.ReadLine();
        string[] words = text.Split(' ');
        Array.Sort(words);
        foreach (var item in words)
        {
            Console.WriteLine(item);
        }
    }
}

