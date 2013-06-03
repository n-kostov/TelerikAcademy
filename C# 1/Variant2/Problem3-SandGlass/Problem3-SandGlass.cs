using System;

class Problem3_SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i <= n / 2; i++)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write('.');
            }
            for (int j = i; j < n - i; j++)
            {
                Console.Write('*');
            }
            for (int j = n - i; j < n; j++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }

        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n / 2 - i - 1; j++)
            {
                Console.Write('.');
            }
            for (int j = n / 2 - i - 1; j < n + i - n / 2 + 1; j++)
            {
                Console.Write('*');
            }
            for (int j = n + i - n / 2 + 1; j < n; j++)
            {
                Console.Write('.');
            }
            Console.WriteLine();
        }
    }
}