using System;

class HexadecimalToDecimal
{
    static void Main()
    {
        string number = Console.ReadLine();
        Console.WriteLine(Convert.ToUInt64(number, 16));

        int n = 0;
        int fact = 1;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (number[i] - '9' <= 0)
            {
                n += (number[i] - '0') * fact;
            } 
            else
            {
                n += (number[i] - 'A' + 10) * fact;
            }
            fact *= 16;
        }
        Console.WriteLine(n);
    }
}

