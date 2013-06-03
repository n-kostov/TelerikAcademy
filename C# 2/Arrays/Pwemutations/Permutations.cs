using System;

class Permutations
{

    static int n;
    static int[] array;

    static void Permute(int current)
    {
        if (current == n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            return;
        }
        for (int i = 1; i <= n; i++)
        {
            bool flag = false;
            for (int j = 0; j < current; j++)
            {
                if (array[j] == i)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                continue;
            } 
            else
            {
                array[current] = i;
                Permute(current + 1);
            }

        }
    }

    static void Main()
    {
        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());
        array = new int[n];
        Permute(0);
    }
}

