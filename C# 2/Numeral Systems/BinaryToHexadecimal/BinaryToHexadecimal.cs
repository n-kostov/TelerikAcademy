using System;

class BinaryToHexadecimal
{
    static void Main()
    {
        string number = Console.ReadLine();
        for (int i = 0; i < number.Length; i += 4)
        {
            string sub = number.Substring(i, 4);
            int fact = 1;
            int n = 0;
            for (int j = 3; j >= 0; j--)
            {
                n += (sub[j] - '0') * fact;
                fact *= 2;
            }
            if (n < 10)
            {
                Console.Write(n);
            } 
            else
            {
                Console.Write((char)(n + 'A' - 10));
            }
        }
        Console.WriteLine();
    }
}

