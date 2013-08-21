using System;

namespace _05.OrderedVariations
{
    public class Program
    {
        private static string[] result;
        private static string[] elements;
        private static int n;
        private static int k;

        public static void PrintOrderedVariations(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                result[index] = elements[i];
                PrintOrderedVariations(index + 1);
            }
        }

        public static void Main(string[] args)
        {
            elements = new string[] { "hi", "a", "b", "c" };
            n = elements.Length;
            k = 2;
            result = new string[k];
            PrintOrderedVariations(0);
        }
    }
}
