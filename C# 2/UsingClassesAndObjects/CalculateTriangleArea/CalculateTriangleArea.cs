using System;

class CalculateTriangleArea
{
    static double CalculateAreaWithAltitude(uint side, uint altitude)
    {
        return side * altitude / 2f;
    }

    static double CalculateAreaWithHerons(uint a, uint b, uint c)
    {
        double p = (a + b + c) / 2f;
        double result = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return result;
    }

    // use angle in radians
    // use Math.PI
    static double CalculateAreaWithAngle(uint a, uint b, double angle)
    {
        double result = a * b * Math.Sin(angle) / 2;
        return result;
    }

    static void Main()
    {
        Console.WriteLine(CalculateAreaWithAltitude(6,4));
        Console.WriteLine(CalculateAreaWithHerons(3,4,5));
        Console.WriteLine(CalculateAreaWithAngle(3,4,Math.PI/2));
    }
}

