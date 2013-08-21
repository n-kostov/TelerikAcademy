namespace _03.Divisors
{
    using System;

    public class Divisors
    {
        private static int n;
        private static int[] array;
        private static int[] result;
        private static bool[] used;

        private static int numberWithLeastDivisors = 0;
        private static int leastDivisors = int.MaxValue;

        public static void Permute(int index)
        {
            if (index >= n)
            {
                CheckCurrentNumber();

                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    result[index] = array[i];
                    used[i] = true;
                    Permute(index + 1);
                    used[i] = false;
                }
            }
        }

        public static void CheckCurrentNumber()
        {
            int currentNumber = int.Parse(string.Join(string.Empty, result));
            int currentNumberDivisors = GetDivisors(currentNumber);
            if (currentNumberDivisors == leastDivisors)
            {
                if (currentNumber < numberWithLeastDivisors)
                {
                    leastDivisors = currentNumberDivisors;
                    numberWithLeastDivisors = currentNumber;
                }
            }
            else if (currentNumberDivisors < leastDivisors)
            {
                leastDivisors = currentNumberDivisors;
                numberWithLeastDivisors = currentNumber;
            }
        }

        public static int GetDivisors(int number)
        {
            int divisorsCount = 0;
            int root = (int)Math.Sqrt(number);
            for (int i = 1; i <= root; i++)
            {
                if (number % i == 0)
                {
                    divisorsCount++;
                }
            }

            if ((double)root == Math.Sqrt(number))
            {
                divisorsCount = (divisorsCount * 2) - 1;
            }
            else
            {
                divisorsCount *= 2;
            }

            return divisorsCount;
        }

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            result = new int[n];
            used = new bool[n];
            Permute(0);

            Console.WriteLine(numberWithLeastDivisors);
        }
    }
}
