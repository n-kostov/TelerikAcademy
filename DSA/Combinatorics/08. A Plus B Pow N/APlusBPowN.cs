namespace _08.A_Plus_B_Pow_N
{
    using System;
    using System.Text;

    public class APlusBPowN
    {
        private static long[] m = new long[55];
        private static int i, j;
        private static int n;

        public static void CalculatePascal(int k)
        {
            for (i = 0; i <= k; i++)
            {
                m[i] = 1;
                if (i > 1)
                {
                    if (k < i - 1)
                    {
                        j = k;
                    }
                    else
                    {
                        j = i - 1;
                    }

                    for (; j >= 1; j--)
                    {
                        m[j] += m[j - 1];
                    }
                }
            } // The answer is in m[k]
        }

        public static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            char firstLetter = expression[1];
            char secondLetter = expression[3];
            Console.ReadLine();
            n = int.Parse(Console.ReadLine());

            CalculatePascal(n);

            int power = n;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= n; i++)
            {
                if (m[i] > 1)
                {
                    sb.Append(m[i]);
                }

                if (power > 0)
                {
                    sb.AppendFormat("({0}^{1})", firstLetter, power);
                }

                if (n - power > 0)
                {
                    sb.AppendFormat("({0}^{1})", secondLetter, n - power);
                }

                if (i < n)
                {
                    sb.Append("+");
                }

                power--;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
