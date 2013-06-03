using System;

class SequenceWithMaxSum
{
    static void Main()
    {
        int[] array = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int maxSum = 0;
        int sum = 0;
        int bestStart = 0;
        int bestLength = 1;
        for (int i = 0; i < array.Length; i++)
        {
            sum = array[i];
            if (sum > maxSum)
            {
                maxSum = sum;
                bestLength = 1;
                bestStart = i;
            }
            for (int j = i + 1; j < array.Length; j++)
            {
                sum += array[j];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    bestLength = j - i;
                    bestStart = i;
                }
            }
        }
        for (int i = bestStart; i <= bestStart + bestLength; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

