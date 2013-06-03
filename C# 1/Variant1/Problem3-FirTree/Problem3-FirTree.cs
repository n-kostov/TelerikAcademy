using System;

class Problem3_FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < (2 * (n - 1)) / 2 - i; j++)
            {
                Console.Write('.');
            }
            for (int j = (2 * (n - 1)) / 2 - i; j < (2 * (n - 1)) / 2 + i - 1; j++)
            {
                Console.Write('*');
            }
            for (int j = (2 * (n - 1)) / 2 + i; j < (2 * (n - 1)); j++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }
        for (int j = 0; j < (2 * (n - 1)) / 2 - 1; j++)
        {
            Console.Write('.');
        }
        for (int j = (2 * (n - 1)) / 2 - 1; j < (2 * (n - 1)) / 2 + 1 - 1; j++)
        {
            Console.Write('*');
        }
        for (int j = (2 * (n - 1)) / 2 + 1; j < (2 * (n - 1)); j++)
        {
            Console.Write('.');
        }
        Console.WriteLine();

    }
}