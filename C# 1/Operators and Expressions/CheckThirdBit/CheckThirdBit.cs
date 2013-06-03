using System;

class CheckThirdBit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int mask = 1;
        mask = mask << 3;
        mask = mask & number;
        mask = mask >> 3;
        Console.WriteLine("The third bit of {0} is {1}", number, mask);
    }
}

