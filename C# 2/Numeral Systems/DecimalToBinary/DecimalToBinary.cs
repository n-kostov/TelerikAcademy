using System;

class DecimalToBinary
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(number, 2));
        string str = "";
        while (number > 0)
        {
            str += number % 2;
            number /= 2;
        }
        for (int i = str.Length - 1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
        Console.WriteLine();
    }
}

