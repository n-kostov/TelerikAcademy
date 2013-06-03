using System;

class PrintMatrixB
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j % 2 == 0)
                {
                    array[i, j] = i + 1 + j * n; 
                } 
                else
                {
                    array[i, j] = n * (j + 1) - i;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

