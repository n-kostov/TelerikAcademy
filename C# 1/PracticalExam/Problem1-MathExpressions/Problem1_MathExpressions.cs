using System;
using System.Numerics;

class Problem1_MathExpressions
{
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());
        decimal result = 0;
        result = n * n + (1 / (m * p)) + 1337;
        result /= (n - 128.523123123m * p);
        result += (decimal)Math.Sin((int)m % 180);
        Console.WriteLine("{0:0.000000}", result);
    }
}

