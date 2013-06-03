using System;

class Problem3_Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int j = 0; j < 2 * n; j++)
        {
            if (j < n)
            {
                Console.Write('.');
            }
            else
            {
                Console.Write('*');
            }
        }
        Console.WriteLine();

        for (int i = 0; i < n - 1; i++)
        {
            int k = n - 1 - i;
            for (int j = 0; j < k; j++)
            {
                    Console.Write('.');
            }
            Console.Write('*');
            for (int j = k + 1; j < 2 * n - 1; j++)
            {
                Console.Write('.');
            }
            Console.Write('*');
            Console.WriteLine();
        }

        for (int j = 0; j < 2 * n; j++)
        {
                Console.Write('*');
        }
        Console.WriteLine();
    }
}

