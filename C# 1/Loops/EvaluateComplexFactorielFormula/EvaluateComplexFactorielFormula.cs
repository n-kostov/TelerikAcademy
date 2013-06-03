using System;

class EvaluateComplexFactorielFormula
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        long result = 1;
        for (int i = 0; i < n; i++)
        {
            result = result * (n - i) * (k - i);
        }
        Console.WriteLine(result);
    }
}

