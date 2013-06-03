using System;
using System.Globalization;

class NumberInDifferentRepresentation
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("number = ");
        double number = double.Parse(Console.ReadLine());
        Console.WriteLine("{0,15:d}", (int)number);
        Console.WriteLine("{0,15:x}", (int)number);
        Console.WriteLine("{0,15:p}", number);
        Console.WriteLine("{0,15:f}", number);
    }
}

