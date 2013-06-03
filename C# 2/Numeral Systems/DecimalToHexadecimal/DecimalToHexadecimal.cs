using System;

class DecimalToHexadecimal
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(number, 16).ToUpper());
        string str = "";
        while (number > 0)
        {
            if ( number % 16 < 10)
            {
                str += number % 16;
            } 
            else
            {
                str += (char)((number % 16) - 10 + 'A');
            }
            
            number /= 16;
        }
        for (int i = str.Length - 1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
        Console.WriteLine();
    }
}

