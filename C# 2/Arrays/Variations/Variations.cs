using System;

class Variations
{
    static int n;
    static int k;
    static int[] array;

    static void Permute(int current)
    {
        if (current == k)
        {
            for (int i = 0; i < k; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            return;
        }
        for (int i = 1; i <= n; i++)
        {
            array[current] = i;
            Permute(current + 1);
        }
    }


    static void Main()
    {
        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());
        Console.Write("k = ");
        k = int.Parse(Console.ReadLine());
        array = new int[k];
        Permute(0);
    }
}

