using System;

class Allocate20Integers
{
    static void Main()
    {
        int[] array = new int[20];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i * 5;
        }
        foreach (int i in array)
        {
            Console.WriteLine(i);
        }
    }
}

