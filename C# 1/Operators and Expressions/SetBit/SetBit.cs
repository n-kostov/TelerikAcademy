using System;

class SetBit
{
    static void Main()
    {
        int n = 5;
        int v = 0;
        int p = 2;
        int mask = 1;
        mask = mask << p;

        if (v == 1)
        {
            n = mask | n;
        }
        else
        {
            mask = ~mask;
            n = mask & n;
        }
        Console.WriteLine(n);
    }
}

