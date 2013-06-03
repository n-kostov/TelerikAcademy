// ********************************
// <copyright file="RectangleUtilitiesDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

using System;

/// <summary>
/// Demo showing how to use the RectangleUtilities class
/// </summary>
internal class RectangleUtilitiesDemo
{
    /// <summary>
    /// The entry point of a console application
    /// </summary>
    public static void Main()
    {
        Rectangle rec = new Rectangle(3, 4);

        Rectangle boundingBox = RectangleUtilities.GetBoundingBoxAfterRotation(rec, Math.PI / 2);

        Console.WriteLine("Width: {0} \nHeight: {1}", boundingBox.Width, boundingBox.Height);
    }
}
