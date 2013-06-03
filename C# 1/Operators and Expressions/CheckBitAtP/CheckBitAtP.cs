using System;

class CheckBitAtP
{
    static void Main()
    {
        int p = int.Parse(Console.ReadLine());
        int v = int.Parse(Console.ReadLine());
        int mask = 1;
        mask = mask << p;
        mask = mask & v;
        mask = mask >> p;
        Console.WriteLine("The bit at position {0} is 1?:{1}", p, mask == 1);
    }
}

