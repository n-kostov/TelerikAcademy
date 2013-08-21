using System;

namespace _02.CombinationsWithDuplications
{
    public class Program
    {
        private static int[] result;
        private static int n;
        private static int k;

        public static void PrintCombinationsWithDuplicates(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (index == 0 || (index > 0 && i >= result[index - 1]))
                {
                    result[index] = i;
                    PrintCombinationsWithDuplicates(index + 1);
                }
            }
        }

        public static void Main(string[] args)
        {
            n = 5;
            k = 2;
            result = new int[k];
            PrintCombinationsWithDuplicates(0);
        }
    }
}
