using System;

class SubsetWithExactSum
{
    static void Main()
    {
        int[] array = { 2, 1, 2, 4, 3, 5, 2, 6 };
        int n = array.Length;
        Console.Write("s = ");
        int s = int.Parse(Console.ReadLine());
        bool found = false;
        int combination = 0;
        for (int i = 1; i < Math.Pow(2, n); i++)
        {
            int currentSum = 0;
            for (int j = 0; j < n; j++)
            {
                int mask = 1;
                mask <<= j;

                if ((i & mask) >> j == 1)
                {
                    currentSum += array[j];
                }
                if (currentSum == s)
                {
                    found = true;
                    combination = i;
                    break;
                }
            }
            if (found)
            {
                break;
            }
        }

        if (found)
        {
            Console.Write("yes ");
            for (int i = 0; i < n; i++)
            {
                int mask = 1;
                mask <<= i;
                if ((combination & mask) >> i == 1)
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}

