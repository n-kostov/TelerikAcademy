using System;

class PoinInCircleOutRectangle
{
    static void Main()
    {
        float x = float.Parse(Console.ReadLine());
        float y = float.Parse(Console.ReadLine());
        bool isInCircle = Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1)) <= 3;
        bool isOutRectangle = x < -1 || x > 5 || y > 1 || y < -1;
        Console.WriteLine("({0},{1}) is in circle and out of the rectangle?:{2}", x, y, isInCircle && isOutRectangle);
    }
}

