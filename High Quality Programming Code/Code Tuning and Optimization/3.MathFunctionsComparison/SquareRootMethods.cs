﻿namespace _3.MathFunctionsComparison
{
    using System;

    public class SquareRootMethods
    {
        public static void CalculateSqrtFloat(float startValue, float endValue)
        {
            for (float i = startValue; i <= endValue; i++)
            {
                Math.Sqrt(i);
            }
        }

        public static void CalculateSqrtDouble(double startValue, double endValue)
        {
            for (double i = startValue; i <= endValue; i++)
            {
                Math.Sqrt(i);
            }
        }

        public static void CalculateSqrtDecimal(decimal startValue, decimal endValue)
        {
            for (decimal i = startValue; i <= endValue; i++)
            {
                Math.Sqrt((double)i);
            }
        }
    }
}
