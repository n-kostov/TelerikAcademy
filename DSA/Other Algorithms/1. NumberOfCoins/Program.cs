namespace _1.NumberOfCoins
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] coins = { 1, 2, 5 };
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            FindNumberOfCoins(n, coins);
        }

        private static void FindNumberOfCoins(int n, int[] coins)
        {
            Array.Sort(coins);
            for (int i = coins.Length - 1; i >= 0; i--)
            {
                int currentCoinUsage = 0;
                while (n > currentCoinUsage)
                {
                    currentCoinUsage++;
                    n -= coins[i];
                }

                Console.Write("{0} coins * {1}, ", currentCoinUsage, coins[i]);
            }

            Console.WriteLine();
        }
    }
}
