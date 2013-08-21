using System;

namespace _06.PrintAllSubsetsOfKElements
{
    public class Program
    {
        private static string[] result;
        private static string[] elements;
        private static bool[] used;

        public static void PrintSubsets(int step, int index, int k, int n)
        {
            if (step >= k)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = index; i < n; i++)
            {
                result[step] = elements[i];
                PrintSubsets(step + 1, i + 1, k, n);
            }
        }

        public static void Main(string[] args)
        {
            elements = new string[] { "test", "rock", "fun", "scissors", "paper" };
            int n = elements.Length;
            used = new bool[n];
            int k = 2;
            result = new string[k];
            PrintSubsets(0, 0, k, n);
        }
    }
}
