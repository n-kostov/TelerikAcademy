using System;

class NDividedByKFactoriels
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long result = 1;
        while (n - k >= 1)
        {
            result *= n;
            n--;
        }
        Console.WriteLine(result);
    }
}

