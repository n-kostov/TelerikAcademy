using System;

class MaximalArea3x3
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("m = ");
        int m = int.Parse(Console.ReadLine());
        int[,] array = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("array[{0},{1}] = ", i, j);
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }
        int bestRow = 0;
        int bestColumn = 0;
        int bestSum = 0;
        for (int i = 0; i < n-2; i++)
        {
            for (int j = 0; j < m - 2; j++)
            {
                int sum = array[i, j] + array[i,j + 1] + array[i, j + 2] +
                    array[i + 1, j] + array[i + 1, j + 1] + array[i + 1, j + 2] +
                    array[i + 2, j] + array[i + 2, j + 1] + array[i + 2, j + 2];
                if (sum > bestSum)
                {
                    bestColumn = j;
                    bestRow = i;
                    bestSum = sum;
                }
            }
        }
        for (int i = bestRow; i < bestRow + 3; i++)
        {
            for (int j = bestColumn; j < bestColumn + 3; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

