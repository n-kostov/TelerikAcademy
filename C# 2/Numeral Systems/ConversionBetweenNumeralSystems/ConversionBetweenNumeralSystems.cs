using System;

class ConversionBetweenNumeralSystems
{
    static void Main()
    {
        byte s = byte.Parse(Console.ReadLine());
        byte d = byte.Parse(Console.ReadLine());

        string number = Console.ReadLine();
        int fact = 1;
        int n = 0;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (number[i] - '0' < 10)
            {
                n += (number[i] - '0') * fact;
                fact *= s;
            } 
            else
            {
                n += (number[i] - 'A' + 10) * fact;
                fact *= s;
            }
        }
        //Console.WriteLine(n);

        string str = "";
        while (n > 0)
        {
            if (n % d < 10)
            {
                str += n % d;
                n /= d;
            } 
            else
            {
                str += (char)((n % d) + 'A' - 10);
                n /= d;
            }
        }
        for (int i = str.Length - 1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
        Console.WriteLine();
    }
}

