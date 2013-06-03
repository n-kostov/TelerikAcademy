using System;

class MinimalAndMaximalOfSequence
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = min;
        for (int i = 0; i < n - 1; i++ )
        {
            int num = int.Parse(Console.ReadLine());
            if (num < min)
            {
                min = num;
            }
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine("Max={0}", max);
        Console.WriteLine("Min={0}", min);
    }
}

