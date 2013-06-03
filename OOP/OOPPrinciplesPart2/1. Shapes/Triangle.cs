using System;

public class Triangle : Shape
{

    public override double CalculateSurface()
    {
        return Height * Width / 2;
    }

    public Triangle(double width, double height)
        : base(width, height)
    { }
}

