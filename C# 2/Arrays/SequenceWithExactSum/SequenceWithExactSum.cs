using System;

class SequenceWithExactSum
{
    static void Main()
    {
        int[] array = { 4, 3, 1, 4, 2, 5, 8 };
        int s = 11;
        int sum = 0;
        int bestStart = 0;
        int bestCount = 1;
        int count = 1;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
            if (s == sum)
            {
                bestStart = i;
                bestCount = count;
                break;
            }

            for (int j = i + 1; j < array.Length; j++)
            {
                sum += array[j];
                count++;
                if (s == sum)
                {
                    bestStart = i;
                    bestCount = count;
                    break;
                }

            }

            if (s == sum)
            {
                break;
            }

            count = 1;
            sum = 0;
        }

        if (s == sum)
        {
            for (int i = bestStart; i < bestStart + bestCount; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Sequence does not exist");
        }
    }
}

