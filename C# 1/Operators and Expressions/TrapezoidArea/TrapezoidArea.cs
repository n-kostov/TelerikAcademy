using System;

class TrapezoidArea
{
    static void Main()
    {
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float h = float.Parse(Console.ReadLine());
        float area = (a + b) / 2 * h;
        Console.WriteLine("The area of the trapezoid is {0}", area);
    }
}

