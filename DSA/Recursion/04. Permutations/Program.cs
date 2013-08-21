using System;

namespace _04.Permutations
{
    public class Program
    {
        private static int[] result;
        private static bool[] used;
        private static int n;

        public static void PrintPermutations(int index)
        {
            if (index >= n)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (!used[i - 1])
                {
                    result[index] = i;
                    used[i - 1] = true;
                    PrintPermutations(index + 1);
                    used[i - 1] = false;
                }
            }
        }

        public static void Main(string[] args)
        {
            n = 4;
            result = new int[n];
            used = new bool[n];
            PrintPermutations(0);
        }
    }
}
