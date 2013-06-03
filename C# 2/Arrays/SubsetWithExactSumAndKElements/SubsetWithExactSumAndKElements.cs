using System;

class SubsetWithExactSumAndKElements
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Console.Write("s = ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("lets read the array");
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        bool found = false;
        int combination = 0;
        for (int i = 1; i < Math.Pow(2, n); i++)
        {
            int currentSum = 0;
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                int mask = 1;
                mask <<= j;

                if ((i & mask) >> j == 1)
                {
                    currentSum += array[j];
                    count++;
                }
                if (currentSum == s && count == k)
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

