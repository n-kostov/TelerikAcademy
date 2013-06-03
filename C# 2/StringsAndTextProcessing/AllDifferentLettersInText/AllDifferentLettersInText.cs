using System;
using System.Collections.Generic;

class AllDifferentLettersInText
{
    static void Main()
    {
        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        Console.Write("text = ");
        string text = Console.ReadLine();
        foreach (char item in text)
        {
            if (!dictionary.ContainsKey(item))
            {
                dictionary.Add(item,1);
            }
            else
            {
                int value = 0;
                dictionary.TryGetValue(item,out value);
                dictionary.Remove(item);
                dictionary.Add(item, value + 1);
            }
        }
        foreach (var item in dictionary)
        {
            Console.WriteLine("{0} - {1}", item.Key, item.Value);
        }
    }
}

