// idea 
// for every length of subset make new array that store them [,]

using System;

class Problem5_SubsetsSums
{
    public static long Combination(int k, int n)
    {
        long sum = 1;
        for (int i = n - k; i <= n; i++)
        {
            sum *= i;
        }
        for (int i = 1; i <= k; i++)
        {
            sum /= i;
        }
        return sum;
    }

    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        byte n = byte.Parse(Console.ReadLine());
        long[] array = new long[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = long.Parse(Console.ReadLine());
        }
        int count = 0;
        int max = (int)Math.Pow(2, n) - 1;
        // this are all the combinations
        for (int i = 1; i <= max; i++)
        {
            long currentSum = 0;
            // binary numbers are also combinations
            // therefore we check them for all possible combinations
            // without the 0 one
            // j represents every digit in the array 
            // depending on the combination we may add it to the sum
            for (int j = 1; j <= n; j++)
            {
                // check j-th position 
                // if it's 1 we add j-th element in the array
                if ((i & (1 << (j - 1))) >> (j-1) == 1)
                {
                    currentSum += array[j - 1];
                }
            }
            if (currentSum == s)
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}

