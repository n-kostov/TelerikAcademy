using System;

class BinaryToDecimal
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToInt64(number.ToString(), 2));
        string str = number.ToString();
        int n = 0;
        int fact = 1;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            n += (str[i] - '0') * fact;
            fact *= 2;
        }
        Console.WriteLine(n);
    }
}

