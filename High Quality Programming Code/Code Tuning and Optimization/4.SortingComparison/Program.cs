namespace _4.SortingComparison
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
            int[] integers = new int[100];

            ArrayUtils.CreateIntArray(integers);
            MeasurePerformance(() => SortingAlgorithms.SelectionSort(integers), "Selection sort ints");
            ArrayUtils.CreateIntArray(integers);
            MeasurePerformance(() => SortingAlgorithms.InsertionSort(integers), "Insertion sort ints");
            ArrayUtils.CreateIntArray(integers);
            MeasurePerformance(() => SortingAlgorithms.QuickSort(integers), "Quick sort ints");

            Console.WriteLine();

            for (int i = 0; i < integers.Length; i++)
            {
                integers[i] = i + 1;
            }

            // the next 3 lines the array is sorted and will remain sorted
            MeasurePerformance(() => SortingAlgorithms.SelectionSort(integers), "Selection sort sorted ints");
            MeasurePerformance(() => SortingAlgorithms.InsertionSort(integers), "Insertion sort sorted ints");
            MeasurePerformance(() => SortingAlgorithms.QuickSort(integers), "Quick sort sorted ints");

            Console.WriteLine();

            Array.Reverse(integers);
            MeasurePerformance(() => SortingAlgorithms.SelectionSort(integers), "Selection sort reversed ints");
            Array.Reverse(integers);
            MeasurePerformance(() => SortingAlgorithms.InsertionSort(integers), "Insertion sort reversed ints");
            Array.Reverse(integers);
            MeasurePerformance(() => SortingAlgorithms.QuickSort(integers), "Quick sort reversed ints");

            Console.WriteLine();

            double[] floatingNumbers = new double[100];

            ArrayUtils.CreateDoubleArray(floatingNumbers);
            MeasurePerformance(() => SortingAlgorithms.SelectionSort(floatingNumbers), "Selection sort doubles");
            ArrayUtils.CreateDoubleArray(floatingNumbers);
            MeasurePerformance(() => SortingAlgorithms.InsertionSort(floatingNumbers), "Insertion sort doubles");
            ArrayUtils.CreateDoubleArray(floatingNumbers);
            MeasurePerformance(() => SortingAlgorithms.QuickSort(floatingNumbers), "Quick sort doubles");

            Console.WriteLine();

            for (int i = 0; i < floatingNumbers.Length; i++)
            {
                floatingNumbers[i] = i + 0.1;
            }

            // the next 3 lines the array is sorted and will remain sorted
            MeasurePerformance(() => SortingAlgorithms.SelectionSort(floatingNumbers), "Selection sort sorted doubles");
            MeasurePerformance(() => SortingAlgorithms.InsertionSort(floatingNumbers), "Insertion sort sorted doubles");
            MeasurePerformance(() => SortingAlgorithms.QuickSort(floatingNumbers), "Quick sort sorted doubles");

            Console.WriteLine();

            Array.Reverse(floatingNumbers);
            MeasurePerformance(() => SortingAlgorithms.SelectionSort(floatingNumbers), "Selection sort reversed doubles");
            Array.Reverse(floatingNumbers);
            MeasurePerformance(() => SortingAlgorithms.InsertionSort(floatingNumbers), "Insertion sort reversed doubles");
            Array.Reverse(floatingNumbers);
            MeasurePerformance(() => SortingAlgorithms.QuickSort(floatingNumbers), "Quick sort reversed doubles");

            Console.WriteLine();

            string[] words = new string[100];

            ArrayUtils.CreateStringArray(words);
            MeasurePerformance(() => SortingAlgorithms.SelectionSort(words), "Selection sort strings");
            ArrayUtils.CreateStringArray(words);
            MeasurePerformance(() => SortingAlgorithms.InsertionSort(words), "Insertion sort strings");
            ArrayUtils.CreateStringArray(words);
            MeasurePerformance(() => SortingAlgorithms.QuickSort(words), "Quick sort strings");

            Console.WriteLine();

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = "word" + (char)('a' + i);
            }

            // the next 3 lines the array is sorted and will remain sorted
            MeasurePerformance(() => SortingAlgorithms.SelectionSort(words), "Selection sort sorted strings");
            MeasurePerformance(() => SortingAlgorithms.InsertionSort(words), "Insertion sort sorted strings");
            MeasurePerformance(() => SortingAlgorithms.QuickSort(words), "Quick sort sorted strings");

            Console.WriteLine();

            Array.Reverse(words);
            MeasurePerformance(() => SortingAlgorithms.SelectionSort(words), "Selection sort reversed strings");
            Array.Reverse(words);
            MeasurePerformance(() => SortingAlgorithms.InsertionSort(words), "Insertion sort reversed strings");
            Array.Reverse(words);
            MeasurePerformance(() => SortingAlgorithms.QuickSort(words), "Quick sort reversed strings");

            Console.WriteLine();
        }
    }
}
