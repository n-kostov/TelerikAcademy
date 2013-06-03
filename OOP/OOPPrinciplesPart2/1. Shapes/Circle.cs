using System;

public class Circle : Shape
{

    public override double CalculateSurface()
    {
        return Height * Width * Math.PI;
    }

    public Circle(double radius)
        : base(radius, radius)
    {
    }
}

