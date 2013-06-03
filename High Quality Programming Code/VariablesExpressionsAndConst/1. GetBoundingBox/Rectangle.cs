// ********************************
// <copyright file="Rectangle.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

using System;

/// <summary>
/// The rectangle figure with width and height
/// </summary>
public class Rectangle
{
    /// <summary>
    /// The width of the rectangle
    /// </summary>
    private double width;

    /// <summary>
    /// The height of the rectangle
    /// </summary>
    private double height;

    /// <summary>
    /// Initializes a new instance of the <see cref="Rectangle"/> class
    /// </summary>
    /// <param name="width">The width of the rectangle</param>
    /// <param name="height">The height of the rectangle</param>
    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// Gets and sets the width of the rectangle
    /// </summary>
    public double Width
    {
        get
        {
            return this.width;
        }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The width cannot be less than or equal to zero!");
            }

            this.width = value;
        }
    }

    /// <summary>
    /// Gets and sets the height of the rectangle
    /// </summary>
    public double Height
    {
        get
        {
            return this.height;
        }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("The height cannot be less than or equal to zero!");
            }

            this.height = value;
        }
    }
}
