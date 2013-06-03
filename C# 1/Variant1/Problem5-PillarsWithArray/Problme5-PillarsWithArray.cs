using System;

class Problem5_PillarsWithArray
{
    static void Main()
    {
        byte[,] array = new byte[8, 8];
        //initialization
        for (int i = 0; i < 8; i++)
        {
            byte n = byte.Parse(Console.ReadLine());
            byte sum = 128;
            for (int j = 0; j < 8; j++)
            {
                if (n >= sum)
                {
                    array[i, j] = 1;
                    n -= sum;
                    sum /= 2;
                }
                else
                {
                    array[i, j] = 0;
                    sum /= 2;
                }
            }
        }

        byte col = 0;

        do
        {
            byte sumleft = 0;
            byte sumright = 0;
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < col; j++)
                {
                    if (array[i, j] == 1)
                    {
                        sumleft++;
                    }
                }
                for (int j = col + 1; j < 8; j++)
                {
                    if (array[i, j] == 1)
                    {
                        sumright++;
                    }
                }

            }

            if (sumleft == sumright)
            {
                Console.WriteLine("{0}", 7 - col);
                Console.WriteLine(sumleft);
                return;
            }
            col++;

        } while (col <= 7);
        Console.WriteLine("No");
    }
}