namespace _10.Roboric_Zomby_Camel
{
    using System;
    using System.Numerics;

    public class RoboricZombyCamel
    {
        private static int n;
        private static ulong[] distances;
        private static ulong[,] combinations;

        public static ulong GetCombination(uint row, uint col)
        {
            if (combinations[row, col] == 0)
            {
                ulong result = 1;
                uint current = 1;
                ulong denominator = 1;
                for (uint i = row - col + 1; i <= row; i++)
                {
                    result *= i;
                    denominator *= current;
                    while (result % denominator != 0)
                    {
                        i++;
                        result *= i;
                        current++;
                        denominator *= current;
                    }

                    result /= denominator;
                    denominator = 1;
                    current++;
                }

                combinations[row, col] = result;
                if (combinations[row, row - col] == 0)
                {
                    combinations[row, row - col] = result;
                }
            }

            return combinations[row, col];
        }

        public static void PopulateCombinations()
        {
            for (uint i = 0; i <= n; i++)
            {
                for (uint j = i; j <= n; j++)
                {
                    GetCombination(j, i);
                }
            }
        }

        public static BigInteger CalculateRopeNeeded()
        {
            BigInteger metres = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    metres += distances[j] * combinations[n - 1, i - 1];
                }
            }

            return metres;
        }

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            distances = new ulong[n];
            combinations = new ulong[n + 1, n + 1];
            PopulateCombinations();
            for (int i = 0; i < n; i++)
            {
                Console.ReadLine();
                string[] coordinates = Console.ReadLine().Split(' ');
                distances[i] = (ulong)Math.Abs(int.Parse(coordinates[0]));
                distances[i] += (ulong)Math.Abs(int.Parse(coordinates[1]));
            }

            BigInteger result = CalculateRopeNeeded();
            BigInteger modulus = ulong.MaxValue;
            modulus += 1;
            Console.WriteLine(result % modulus);
        }
    }
}
