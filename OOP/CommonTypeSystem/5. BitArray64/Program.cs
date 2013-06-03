using System;

//  5.Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.


class Program
{
    static void Main(string[] args)
    {
        Console.Write("number = ");
        ulong number = ulong.Parse(Console.ReadLine());

        BitArray64 bitArray = new BitArray64(number);

        Console.Write("The binary representation of {0} in ulong is: ", number);
        foreach (var index in bitArray)
        {
            Console.Write(index + " ");
        }
        Console.WriteLine();
    }
}
