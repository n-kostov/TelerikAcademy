using System;

class PrintMatrixOfNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0} ", i + j);
            }
            Console.WriteLine();
        }
    }
}

