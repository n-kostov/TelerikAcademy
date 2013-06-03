using System;

class PrintMatrixC
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];
        int counter = 1;
        for (int i = n -1; i >= 0; i--)
        {
            int k = i;
            for (int j = 0; j < n; j++)
            {
                array[k, j] = counter;
                counter++;
                k++;
                if (k > n - 1)
                {
                    break;
                }
            }
        }
        for (int i = 1; i < n; i++)
        {
            int k = i;
            for (int j = 0; j < n; j++)
            {
                array[j, k] = counter;
                counter++;
                k++;
                if (k > n - 1)
                {
                    break;
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

