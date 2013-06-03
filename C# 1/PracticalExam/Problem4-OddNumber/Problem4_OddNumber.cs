using System;

class Problem4_OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] array = new long[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = long.Parse(Console.ReadLine());
        }
        long result = 0;
        for (int i = 0; i < n; i++)
        {
            result ^= array[i];
        }
        Console.WriteLine(result);
    }
}
