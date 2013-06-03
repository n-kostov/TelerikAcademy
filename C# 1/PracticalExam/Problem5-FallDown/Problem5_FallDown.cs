using System;

class Problem5_FallDown
{
    static void Main()
    {
        byte[] array = new byte[8];
        for (byte i = 0; i < 8; i++)
        {
            array[i] = byte.Parse(Console.ReadLine());
        }

        for (byte i = 6; i <= 6; i--)
        {
            //int counter = 128;
            for (byte j = 0; j < 8; j++)
            {
                byte k = i;
                if ((array[i] & (1 << j)) >> j == 1)
                {
                    while ((k < 7) && ((array[k + 1] & (1 << j)) >> j == 0))
                    {
                        array[k + 1] += (byte)(1 << j);
                        array[k] -= (byte)(1 << j);
                        k++;
                    }
                }
            }
        }
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}

