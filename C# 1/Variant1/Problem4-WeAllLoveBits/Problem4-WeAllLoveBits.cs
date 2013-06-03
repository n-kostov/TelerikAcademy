using System;

class Problem4_WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            uint p = uint.Parse(Console.ReadLine());
            uint powGreaterThanP = 1;
            int j = 1;
            while (powGreaterThanP * 2 - 1 < p)
            {
                powGreaterThanP *= 2;
                j++;
            }
            uint p_console = 0;
            uint p_dot = 0;
            for (int k = 0; k < j; k++)
            {
                uint mask = 1;
                mask = mask << j - k - 1;
                mask = mask & p;
                mask = mask >> j - k - 1;
                if (mask == 1)
                {
                    p_console += 0 * (uint)Math.Pow(2, j - k - 1);
                }
                else
                {
                    p_console += 1 * (uint)Math.Pow(2, j - k - 1);
                }
                p_dot += mask * (uint)Math.Pow(2, k);
            }
            uint p_new = (p ^ p_console) & p_dot;
            Console.WriteLine(p_new);
        }
    }
}