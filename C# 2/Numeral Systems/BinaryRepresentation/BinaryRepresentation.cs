using System;

class BinaryRepresentation
{
    static void Main()
    {
        short number = short.Parse(Console.ReadLine());
        string str = Convert.ToString(number , 2);
        Console.WriteLine(str.PadLeft(16,'0'));
    }
}

