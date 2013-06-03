namespace _3.MathFunctionsComparison
{
    using System;

    public class NaturalLogarithmMethods
    {
        public static void CalculateLogFloat(float startValue, float endValue)
        {
            for (float i = startValue; i <= endValue; i++)
            {
                Math.Log(i);
            }
        }

        public static void CalculateLogDouble(double startValue, double endValue)
        {
            for (double i = startValue; i <= endValue; i++)
            {
                Math.Log(i);
            }
        }

        public static void CalculateLogDecimal(decimal startValue, decimal endValue)
        {
            for (decimal i = startValue; i <= endValue; i++)
            {
                Math.Log((double)i);
            }
        }
    }
}
