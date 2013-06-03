using System;

class MostFrequentNumberInArray
{
    static void Main()
    {
        int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        int maxCount = 1;
        int count = 1;
        int element = 0;
        for (int i = 0; i < array.Length; i++)
        {
            count = 1;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    element = array[i];
                }
            }
        }
        Console.WriteLine("{0} - {1} times", element, maxCount);
    }
}

