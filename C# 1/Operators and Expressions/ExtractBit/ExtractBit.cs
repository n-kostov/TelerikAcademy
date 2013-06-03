using System;

class ExtractBit
{
    static void Main()
    {
        int i = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int mask = 1;
        mask = mask << b;
        mask = mask & i;
        mask = mask >> b;
        Console.WriteLine("The bit at position {0} is {1}", b, mask);
    }
}

