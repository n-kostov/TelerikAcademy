using System;

public abstract class Shape
{
    private double width;
    private double height;

    public double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The height cannot be less than or equal to 0!");
            }
            this.height = value;
        }
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The width cannot be less than or equal to 0!");
            }
            this.width = value;
        }
    }

    protected Shape(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public abstract double CalculateSurface();
}
