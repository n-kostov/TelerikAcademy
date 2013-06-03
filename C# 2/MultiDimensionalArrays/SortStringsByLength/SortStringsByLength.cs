using System;
using System.Collections.Generic;

class SortStringsByLength
{
    public static void Sort(string[] array)
    {
        string[] tempArray = new string[array.Length];
        List<int> list = new List<int>();
        for (int i = 0; i < array.Length; i++)
        {
            list.Add(array[i].Length);
        }
        int index = 0;

        while (index != array.Length)
        {
            int count = list[0];
            int position = 0;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < count)
                {
                    count = list[i];
                    position = i;
                }
            }
            tempArray[index] = array[position];
            list[position] = int.MaxValue;
            index++;
        }
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = tempArray[i];
        }
    }

    static void Main()
    {
        string[] array = { "hahaha", "haha", "ha", "hah" };
        foreach (string item in array)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        Sort(array);
        foreach (string item in array)
        {
            Console.WriteLine(item);
        }
    }
}

