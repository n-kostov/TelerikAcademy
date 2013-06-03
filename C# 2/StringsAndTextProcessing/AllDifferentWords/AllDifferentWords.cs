using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class AllDifferentWords
{
    static void Main()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        Console.Write("text = ");
        string text = Console.ReadLine();
        Regex regex = new Regex(@"\b\w+\b");
        foreach (var item in regex.Matches(text))
        {
            if (!dictionary.ContainsKey(item.ToString()))
            {
                dictionary.Add(item.ToString(), 1);
            }
            else
            {
                int value = 0;
                dictionary.TryGetValue(item.ToString(), out value);
                dictionary.Remove(item.ToString());
                dictionary.Add(item.ToString(), value + 1);
            }
        }
        foreach (var item in dictionary)
        {
            Console.WriteLine("{0} - {1}", item.Key, item.Value);
        }
    }
}

