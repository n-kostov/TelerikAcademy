using System;

class PrintMatrixA
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = i + 1 + j * 4;
            }
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}

