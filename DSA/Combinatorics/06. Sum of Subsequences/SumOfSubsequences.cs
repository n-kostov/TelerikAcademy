namespace _06.Sum_of_Subsequences
{
    using System;

    public class SumOfSubsequences
    {
        private static int k;
        private static int n;

        public static long GetDifferentSequences()
        {
            int current = 1;
            long nominator = 1;
            long denominator = 1;

            current = n - k;

            denominator = GetFactorial(k);
            while (nominator % denominator != 0)
            {
                nominator *= current;
                current++;
            }

            nominator = nominator / denominator;

            for (int i = current; i < n; i++)
            {
                nominator *= i;
            }

            return nominator;
        }

        public static long GetFactorial(int number)
        {
            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        public static void Main(string[] args)
        {
            int tests = int.Parse(Console.ReadLine());

            for (int i = 0; i < tests; i++)
            {
                string[] parameters = Console.ReadLine().Split(' ');
                n = int.Parse(parameters[0]);
                k = int.Parse(parameters[1]);
                string[] numbers = Console.ReadLine().Split(' ');

                int sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += int.Parse(numbers[j]);
                }

                long combination = GetDifferentSequences();
                Console.WriteLine(sum * combination);
            }
        }
    }
}
