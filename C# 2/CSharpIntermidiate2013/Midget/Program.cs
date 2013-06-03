using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midget
{
    



    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            char[] delims = { ',', ' ' };
            string[] lines = firstLine.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            int[] valley = new int[lines.Length];
            for (int i = 0; i < valley.Length; i++)
            {
                valley[i] = int.Parse(lines[i]);
            }

            int m = int.Parse(Console.ReadLine());
            string[] patterns = new string[m];
            for (int i = 0; i < m; i++)
			{
			    patterns[i] = Console.ReadLine();
			}

            long mostCoins = 0;
            for (int i = 0; i < m; i++)
            {
                string[] line = patterns[i].Split(delims, StringSplitOptions.RemoveEmptyEntries);
                int[] pattern = new int[line.Length];
                for (int j = 0; j < pattern.Length; j++)
                {
                    pattern[j] = int.Parse(line[j]);
                }

                long coinsCurrentPattern = 0;
                bool[] used = new bool[valley.Length];
                coinsCurrentPattern += valley[0];
                used[0] = true;
                int l = 0;  // current position
                int k = 0;  //  pattern iterator
                while (true)
                {
                    if ( l + pattern[k] < 0 || l + pattern[k] > valley.Length - 1 || used[l + pattern[k]] == true)
                    {
                        break;
                    } 
                    else
                    {
                        coinsCurrentPattern += valley[l + pattern[k]];
                        used[l + pattern[k]] = true;
                        l += pattern[k];
                        k++;
                        if (k > pattern.Length - 1)
                        {
                            k = 0;
                        }

                    }
                }
                if (coinsCurrentPattern > mostCoins)
                {
                    mostCoins = coinsCurrentPattern;
                }
            }
            Console.WriteLine(mostCoins);
        }
    }
}
