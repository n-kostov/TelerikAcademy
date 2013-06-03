namespace _2.ComparePerfOfNumberTypes
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
            int numberOfRepetitions = 100000;
            MeasurePerformance(() => AdditionMethods.AddInt(2, numberOfRepetitions), "Adding int");
            MeasurePerformance(() => AdditionMethods.AddLong(2L, numberOfRepetitions), "Adding long");
            MeasurePerformance(() => AdditionMethods.AddFloat(2.1f, numberOfRepetitions), "Adding float");
            MeasurePerformance(() => AdditionMethods.AddDouble(2.1d, numberOfRepetitions), "Adding double");
            MeasurePerformance(() => AdditionMethods.AddDecimal(2.1m, numberOfRepetitions), "Adding decimal");

            Console.WriteLine();

            MeasurePerformance(() => SubtractionMethods.SubtractInt(2, numberOfRepetitions), "Subtracting int");
            MeasurePerformance(() => SubtractionMethods.SubtractLong(2L, numberOfRepetitions), "Subtracting long");
            MeasurePerformance(() => SubtractionMethods.SubtractFloat(2.1f, numberOfRepetitions), "Subtracting float");
            MeasurePerformance(() => SubtractionMethods.SubtractDouble(2.1d, numberOfRepetitions), "Subtracting double");
            MeasurePerformance(() => SubtractionMethods.SubtractDecimal(2.1m, numberOfRepetitions), "Subtracting decimal");

            Console.WriteLine();

            MeasurePerformance(() => IncrementionMethods.IncrementInt(2, numberOfRepetitions), "Incrementing int");
            MeasurePerformance(() => IncrementionMethods.IncrementLong(2L, numberOfRepetitions), "Incrementing long");
            MeasurePerformance(() => IncrementionMethods.IncrementFloat(2.1f, numberOfRepetitions), "Incrementing float");
            MeasurePerformance(() => IncrementionMethods.IncrementDouble(2.1d, numberOfRepetitions), "Incrementing double");
            MeasurePerformance(() => IncrementionMethods.IncrementDecimal(2.1m, numberOfRepetitions), "Incrementing decimal");

            Console.WriteLine();

            numberOfRepetitions = 50;
            MeasurePerformance(() => MultiplicationMethods.MultiplyInt(2, numberOfRepetitions), "Multiplying int");
            MeasurePerformance(() => MultiplicationMethods.MultiplyLong(2L, numberOfRepetitions), "Multiplying long");
            MeasurePerformance(() => MultiplicationMethods.MultiplyFloat(2.1f, numberOfRepetitions), "Multiplying float");
            MeasurePerformance(() => MultiplicationMethods.MultiplyDouble(2.1d, numberOfRepetitions), "Multiplying double");
            MeasurePerformance(() => MultiplicationMethods.MultiplyDecimal(2.1m, numberOfRepetitions), "Multiplying decimal");

            Console.WriteLine();

            numberOfRepetitions = 100000;
            MeasurePerformance(() => DivisionMethods.DivideInt(2, numberOfRepetitions), "Dividing int");
            MeasurePerformance(() => DivisionMethods.DivideLong(2L, numberOfRepetitions), "Dividing long");
            MeasurePerformance(() => DivisionMethods.DivideFloat(2.1f, numberOfRepetitions), "Dividing float");
            MeasurePerformance(() => DivisionMethods.DivideDouble(2.1d, numberOfRepetitions), "Dividing double");
            MeasurePerformance(() => DivisionMethods.DivideDecimal(2.1m, numberOfRepetitions), "Dividing decimal");
        }
    }
}
