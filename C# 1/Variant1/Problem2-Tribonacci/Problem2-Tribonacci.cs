using System;
using System.Numerics;
class Problem2_Tribonacci
{
    static void Main()
    {
        BigInteger a = int.Parse(Console.ReadLine());
        BigInteger b = int.Parse(Console.ReadLine());
        BigInteger c = int.Parse(Console.ReadLine());
        ushort n = ushort.Parse(Console.ReadLine());
        BigInteger[] array = new BigInteger[n];
        array[0] = a;
        array[1] = b;
        array[2] = c;
        for (int i = 3; i < n; i++)
        {
            array[i] = array[i - 1] + array[i - 2] + array[i - 3];
        }
        Console.WriteLine(array[n - 1]);
    }
}