using System;

class ElementFrequencyInArray
{

    static int CountElementFrequencyInArray(int element, int[] array)
    {
        int count = 0;
        foreach (int item in array)
        {
            if (item == element)
            {
                count++;
            }
        }
        return count;
    }

    static void Main()
    {
        int[] array = { 1, 2, 6, 1, 8, 1, 2 };
        Console.Write("element = ");
        int element = int.Parse(Console.ReadLine());
        Console.WriteLine(CountElementFrequencyInArray(element, array));
    }
}

