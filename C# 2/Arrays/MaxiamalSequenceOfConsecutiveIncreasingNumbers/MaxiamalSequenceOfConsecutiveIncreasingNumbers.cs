using System;

class MaxiamalSequenceOfConsecutiveIncreasingNumbers
{
    static void Main()
    {
        int[] array = { 3, 2, 3, 4, 2, 2, 4 };
        int start = 0;
        int bestStart = 0;
        int maxCount = 1;
        int count = 1;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                count++;
                //start = i;
            }
            else
            {
                start = i;
                if (count > maxCount)
                {
                    maxCount = count;
                    bestStart = start - maxCount + 1;
                }
                count = 1;

            }
        }

        for (int i = bestStart; i < bestStart + maxCount; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

