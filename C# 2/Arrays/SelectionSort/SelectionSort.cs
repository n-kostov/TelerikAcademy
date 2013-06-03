using System;

class SelectionSort
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < n - 1; i++)
        {
            int min = array[i];
            int k = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < min)
                {
                    min = array[j];
                    k = j;
                }
            }
            int swap = array[i];
            array[i] = array[k];
            array[k] = swap;
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

