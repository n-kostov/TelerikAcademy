using System;

class printWithAccuracy
{
    static void Main()
    {
        double sum = 1;
        for (int i = 2; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                sum += 1f / i;
            } 
            else
            {
                sum -= 1f / i;
            }
        }
        Console.WriteLine("The sum={0:F3}", sum);
    }
}

