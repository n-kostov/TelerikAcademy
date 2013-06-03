using System;

class SumOfFactoiels
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        double s = 1;
        for (int i = 1; i <= n; i++)
        {
            double result = 1;
            int num = i;
            while (num >= 1)
            {
                result *= (num/(float)x);
                num--;
            }
            s += result;
        }
        Console.WriteLine(s);
    }
}

