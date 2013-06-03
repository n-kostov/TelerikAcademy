using System;
using System.Numerics;

class TrailingZeros
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger result = 1;
        for (int i = 0; i < n; i++)
        {
            result *= (n - i);
        }

        int divider = 5;
        int trailingZerosCount = 0;
        while (divider <= n)
        {
            trailingZerosCount += n / divider;
            divider *= divider;
        }
        Console.WriteLine("{0}! = {1}", n, result);
        Console.WriteLine(trailingZerosCount);

    }
}

