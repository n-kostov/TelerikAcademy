namespace _04.Colored_Balls_Sequence
{
    using System;

    public class ColoredBallsSequence
    {
        private static char[] balls;

        // probably could be done faster
        // directly by n!/colorCount1!*..*colorCountk!
        public static long GetDifferentSequences()
        {
            int count = 1;
            int current = 1;
            long nominator = 1;
            long denominator = 1;
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
            balls = Console.ReadLine().ToCharArray();
            Array.Sort(balls);
            long differentSequencesCount = GetDifferentSequences();

            Console.WriteLine(differentSequencesCount);
        }
    }
}
