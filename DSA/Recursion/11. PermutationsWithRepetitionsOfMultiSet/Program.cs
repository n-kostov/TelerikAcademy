using System;

namespace _11.PermutationsWithRepetitionsOfMultiSet
{
    public class Program
    {
        private static int[] multiSet = { 1, 5, 5, 5, 5, 5 };

        public static void PrintPermutationsWithDuplicates(int index, int n)
        {
            Console.WriteLine(string.Join(", ", multiSet));

            int oldValue = 0;
            for (int i = n - 2; i >= index; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (multiSet[i] != multiSet[j])
                    {
                        oldValue = multiSet[i];
                        multiSet[i] = multiSet[j];
                        multiSet[j] = oldValue;

                        PrintPermutationsWithDuplicates(i + 1, n);
                    }
                }

                oldValue = multiSet[i];
                for (int k = i; k < n - 1; k++)
                {
                    multiSet[k] = multiSet[k + 1];
                }

                multiSet[n - 1] = oldValue;
            }
        }

        public static void Main(string[] args)
        {
            Array.Sort(multiSet);
            PrintPermutationsWithDuplicates(0, multiSet.Length);
        }
    }
}
