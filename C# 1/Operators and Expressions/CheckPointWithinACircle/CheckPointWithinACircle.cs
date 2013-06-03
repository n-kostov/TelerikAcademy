using System;

class CheckPointWithinACircle
{
    static void Main()
    {
        float x = float.Parse(Console.ReadLine());
        float y = float.Parse(Console.ReadLine());
        bool isWithinACircle = Math.Sqrt(x * x + y * y) <= 5;
        if (isWithinACircle)
        {
            Console.WriteLine("Point ({0},{1}) is within the circle(0,5)", x, y);
        }
        else
        {
            Console.WriteLine("Point ({0},{1}) is not within the circle(0,5)", x, y);
        }
    }
}

