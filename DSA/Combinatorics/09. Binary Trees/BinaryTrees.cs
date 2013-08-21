namespace _09.Binary_Trees
{
    using System;
    using System.Numerics;

    public class BinaryTrees
    {
        private static char[] balls;
        private static int n;

        public static BigInteger GetDifferentSequences()
        {
            int count = 1;
            int current = 1;
            BigInteger nominator = 1;
            BigInteger denominator = 1;
            for (int i = 0; i < balls.Length - 1; i++)
            {
                if (balls[i] == balls[i + 1])
                {
                    count++;
                }
                else
                {
                    denominator = GetFactorial(count);
                    while (nominator % denominator != 0)
                    {
                        nominator *= current;
                        current++;
                    }

                    nominator = nominator / denominator;
                    count = 1;
                }
            }

            if (count > 1)
            {
                denominator = GetFactorial(count);
                while (nominator % denominator != 0)
                {
                    nominator *= current;
                    current++;
                }

                nominator = nominator / denominator;
            }

            for (int i = current; i <= balls.Length; i++)
            {
                nominator *= i;
            }

            return nominator;
        }

        public static long GetNthCatalanNumber()
        {
            int current = 1;
            long nominator = 1;
            long denominator = 1;
            for (int i = n + 2; i <= 2 * n; i++)
            {
                nominator *= i;
                denominator *= current;
                while (nominator % denominator != 0)
                {
                    i++;
                    nominator *= i;
                }

                nominator /= denominator;
                denominator = 1;
                current++;
            }

            return nominator / current;
        }

        public static BigInteger GetFactorial(int number)
        {
            BigInteger result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        public static void Main(string[] args)
        {
            balls = Console.ReadLine().ToCharArray();
            Array.Sort(balls);
            n = balls.Length;
            BigInteger differentSequences = GetDifferentSequences();
            long nthCatalan = GetNthCatalanNumber();
            BigInteger result = nthCatalan * differentSequences;
            Console.WriteLine(result);
        }
    }
}
