using System;

class Print1ToN
{
    static void Main()
    {
        int n = 0;
        while (!int.TryParse(Console.ReadLine(), out n)) ;
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("{0}", i);
        }
    }
}

