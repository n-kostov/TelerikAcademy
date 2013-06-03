using System;

class NthCatalanNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double result = 1;
        for (int i = 2; i < n; i++)
        {
            result = result * (n - 1 + i) / (i);
        }
        Console.WriteLine((int)result);

    }
}

