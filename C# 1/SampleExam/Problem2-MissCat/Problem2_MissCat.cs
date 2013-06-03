using System;

class Problem2_MissCat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        byte[] array = new byte[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = byte.Parse(Console.ReadLine());
        }

        int[] cats = new int[10];
        for (int i = 0; i < 10; i++)
        {
            cats[i] = 0;
        }

        int count = 1;
        //int bestCount = 0;
        int bestElement = 1;
        for (int i = 0; i < n; i++)
        {
            cats[array[i] - 1]++;
        }

        for (int i = 0; i < 9; i++)
        {
            count = cats[i];
            for (int j = i + 1; j < 10; j++)
            {
                if (cats[j] > count)
                {
                    count = cats[j];
                    bestElement = j + 1;
                }
            }
            break;
        }
        Console.WriteLine(bestElement);

    }
}

