// ********************************
// <copyright file="RectangleUtilities.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

using System;

/// <summary>
/// Utilities about a rectangle figure
/// </summary>
public class RectangleUtilities
{
    /// <summary>
    /// Get the bounding box of a rectangle rotated by a given angle.
    /// </summary>
    /// <param name="rectangle">The rectangle to rotate</param>
    /// <param name="angleInRadians">The angle in radians to rotate the rectangle</param>
    /// <returns>The bounding box of the rotated rectangle</returns>
    public static Rectangle GetBoundingBoxAfterRotation(Rectangle rectangle, double angleInRadians)
    {
        double width = (rectangle.Width * Math.Abs(Math.Cos(angleInRadians))) +
            (rectangle.Height * Math.Abs(Math.Sin(angleInRadians)));
        double height = (rectangle.Height * Math.Abs(Math.Cos(angleInRadians))) +
            (rectangle.Width * Math.Abs(Math.Sin(angleInRadians)));

        return new Rectangle(width, height);
    }
}
