using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessmen
{
    class Program
    {
        static long mod = 100003;

        static long modular(long a, long b)
        {
            long result = 1;
            while (b > 0)
            {
                if (b % 2 == 1)
                {
                    result = (result * a) % mod;
                }
                a = (a * a) % mod;
                b = b / 2;
            }
            return result;
        }

        public static void Main()
        {
            long[] a = new long[71];
            a[0] = 1;
            a[1] = 1;
            for (int i = 2; i <= 70; i++)
            {
                a[i] = (i * a[i - 1]) % mod;
            }

            int n = int.Parse(Console.ReadLine()) / 2;
            long ans = a[2 * n];
            long ans1 = a[n];
            ans1 = (ans1 * ans1) % mod;
            ans1 = modular(ans1, mod - 2);
            ans1 %= mod;
            ans = (ans * ans1) % mod;
            long h = modular((long)(n + 1), mod - 2);
            ans = (ans * h) % mod;
            Console.WriteLine(ans);
        }


        //static long[] dp;
        //static int n;

        //public static void solve()
        //{
        //    dp[0] = 1;
        //    for (int i = 1; i <= n / 2; i++)
        //    {
        //        for (int j = 0; j <= i - 1; j++)
        //        {
        //            dp[i] += dp[j] * dp[i - j - 1];
        //        }
        //    }
        //}

        //public static void Main()
        //{
        //    n = int.Parse(Console.ReadLine());
        //    dp = new long[n /2];
        //    solve();
        //    Console.WriteLine(dp[n / 2]);
        //}
    }
}
