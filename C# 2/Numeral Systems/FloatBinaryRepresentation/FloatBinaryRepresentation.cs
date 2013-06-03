using System;

class FloatBinaryRepresentation
{
    static void Main()
    {
        float number = float.Parse(Console.ReadLine());
        byte[] arr = BitConverter.GetBytes(number);
        Console.WriteLine("sign = {0}", ((arr[3] & (1 << 7)) >> 7));
        string str = "";
        for (int i = 6; i >= 0; i--)
        {
            str += (arr[3] & (1 << i)) >> i;
        }
        str += ((arr[2] & (1 << 7)) >> 7);
        Console.WriteLine("exponent = {0}", str);
        str = "";
        for (int i = 6; i >= 0; i--)
        {
            str += (arr[2] & (1 << i)) >> i;
        }
        for (int i = 7; i >= 0; i--)
        {
            str += (arr[1] & (1 << i)) >> i;
        }
        for (int i = 7; i >= 0; i--)
        {
            str += (arr[0] & (1 << i)) >> i;
        }
        Console.WriteLine("mantissa = {0}", str);
    }
}

