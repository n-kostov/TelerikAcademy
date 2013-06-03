using System;

class SumOfN_Numbers
{
    static void Main()
    {
        int n = 0;
        while (!int.TryParse(Console.ReadLine(), out n)) ;
        float sum = 0;
        for (int i = 0; i < n; i++)
        {
            int number = 0;
            while (!int.TryParse(Console.ReadLine(), out number)) ;
            sum += number;
        }
        Console.WriteLine("The sum = {0}", sum);
    }
}

