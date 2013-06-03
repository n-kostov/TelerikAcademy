// ********************************
// <copyright file="ArrayStatistics.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************

using System;

/// <summary>
/// Contains methods which perform statistical calculations over an array.
/// </summary>
public static class ArrayStatistics
{
    /// <summary>
    /// Returns the maximum value in <paramref name="array"/>.
    /// </summary>
    /// <param name="array">The sequence of numbers.</param>
    /// <returns>The maximum value in sequence of numbers.</returns>
    public static double Max(double[] array)
    {
        if (array.Length == 0)
        {
            throw new ArgumentException("Sequence contains no elements.");
        }

        double max = double.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }

        return max;
    }

    /// <summary>
    /// Returns the minimum value in <paramref name="array"/>.
    /// </summary>
    /// <param name="array">The sequence of numbers.</param>
    /// <returns>The minimum value in sequence of numbers.</returns>
    public static double Min(double[] array)
    {
        if (array.Length == 0)
        {
            throw new ArgumentException("Sequence contains no elements.");
        }

        double min = double.MaxValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }

        return min;
    }

    /// <summary>
    /// Computes the average of a sequence of numbers.
    /// </summary>
    /// <param name="array">The sequence of numbers.</param>
    /// <returns>The average value of the numbers in the sequence.</returns>
    public static double Average(double[] array)
    {
        int arrayLength = array.Length;

        if (arrayLength == 0)
        {
            throw new ArgumentException("Sequence contains no elements.");
        }

        double sum = 0;

        for (int i = 0; i < arrayLength; i++)
        {
            sum += array[i];
        }

        double average = sum / arrayLength;
        return average;
    }
}