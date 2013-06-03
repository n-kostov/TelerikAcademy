using System;

public class Rectangle : Shape
{
    public override double CalculateSurface()
    {
        return Width * Height;
    }

    public Rectangle(double width, double height)
        : base(width, height)
    {
    }
}

