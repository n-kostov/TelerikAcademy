namespace _4.SortingComparison
{
    using System;
    using System.Text;

    public static class ArrayUtils
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random r = new Random();

        public static void CreateIntArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = r.Next();
            }
        }

        public static void CreateDoubleArray(double[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = r.NextDouble();
            }
        }

        public static void CreateStringArray(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = GenerateStringFromCharArray();
            }
        }

        private static string GenerateStringFromCharArray()
        {
            int length = r.Next(10, 25);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                builder.Append(Chars[r.Next(0, Chars.Length)]);
            }

            return builder.ToString();
        }
    }
}
