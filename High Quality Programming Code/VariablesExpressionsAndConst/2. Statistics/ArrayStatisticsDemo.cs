// ********************************
// <copyright file="ArrayStatisticsDemo.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

using System;

/// <summary>
/// Demo showing how to use <see cref="ArrayStatistics"/>
/// </summary>
internal class ArrayStatisticsDemo
{
    /// <summary>
    /// The entry method for a console application
    /// </summary>
    public static void Main()
    {
        double[] sequence = { 2, 3, 7, 5, 4 };

        Console.WriteLine(ArrayStatistics.Min(sequence));

        Console.WriteLine(ArrayStatistics.Max(sequence));

        Console.WriteLine(ArrayStatistics.Average(sequence));
    }
}