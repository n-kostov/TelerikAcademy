// using binary operations
using System;

class Problem5_Pillars
{
    static void Main()
    {
        byte[] array = new byte[8];
        for (byte i = 0; i < 8; i++)
        {
            array[i] = byte.Parse(Console.ReadLine());
        }

        for (byte i = 7; i <= 7; i--)
        {
            byte leftCount = 0;
            byte rightCount = 0;

            for (byte j = (byte)(i + 1); j <= 7; j++)
            {
                for (byte k = 0; k < 8; k++)
                {
                    if ((array[k] & (1 << j)) >> j == 1)
                    {
                        leftCount++;
                    }
                }
            }
            for (byte j = 0; j < i; j++)
            {
                for (byte k = 0; k < 8; k++)
                {
                    if ((array[k] & (1 << j)) >> j == 1)
                    {
                        rightCount++;
                    }
                }
            }

            if (leftCount == rightCount)
            {
                Console.WriteLine(i);
                Console.WriteLine(leftCount);
                return;
            }

        }
        Console.WriteLine("No");
    }
}

