using System;

class PrintSequence
{
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i + 2);
            }
            else
            {
                Console.WriteLine(-(i + 2));
            }
        }
    }
}

