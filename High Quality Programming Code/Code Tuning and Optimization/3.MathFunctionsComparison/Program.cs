namespace _3.MathFunctionsComparison
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        public static void MeasurePerformance(Action method, string methodName)
        {
            Console.Write(methodName + " done in: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            method();
            timer.Stop();
            Console.WriteLine(timer.Elapsed.TotalMilliseconds + "ms");
        }

        public static void Main(string[] args)
        {
            int endValue = 100000;
            MeasurePerformance(() => SquareRootMethods.CalculateSqrtFloat(2.1f, endValue), "Square root of float");
            MeasurePerformance(() => SquareRootMethods.CalculateSqrtDouble(2.1, endValue), "Square root of double");
            MeasurePerformance(() => SquareRootMethods.CalculateSqrtDecimal(2.1m, endValue), "Square root of decimal");

            Console.WriteLine();

            MeasurePerformance(() => NaturalLogarithmMethods.CalculateLogFloat(2.1f, endValue), "Log of float");
            MeasurePerformance(() => NaturalLogarithmMethods.CalculateLogDouble(2.1, endValue), "Log of double");
            MeasurePerformance(() => NaturalLogarithmMethods.CalculateLogDecimal(2.1m, endValue), "Log of decimal");

            Console.WriteLine();

            MeasurePerformance(() => SinusMethods.CalculateSinFloat(2.1f, endValue), "Sin of float");
            MeasurePerformance(() => SinusMethods.CalculateSinDouble(2.1, endValue), "Sin of double");
            MeasurePerformance(() => SinusMethods.CalculateSinDecimal(2.1m, endValue), "Sin of decimal");
        }
    }
}
