using System;

namespace _01.NNestedLoops
{
    public class Program
    {
        private static int[] result;

        public static void PrintNestedLoop(int index, int n)
        {
            if (index >= n)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                result[index] = i;
                PrintNestedLoop(index + 1, n);
            }
        }

        public static void Main(string[] args)
        {
            int n = 4;
            result = new int[n];
            PrintNestedLoop(0, n);
        }
    }
}
