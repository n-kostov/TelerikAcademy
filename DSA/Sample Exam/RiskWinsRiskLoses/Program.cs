using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLoses
{
    class Program
    {
        private static int[] initial;
        private static int[] target;
        private static HashSet<string> forbidden;
        private static bool[] used;
        private static int minOperations = int.MaxValue;

        static void FindSolution(int step)
        {
            if (step >= minOperations)
            {
                return;
            }

            if (initial[0] == target[0] && initial[1] == target[1] && initial[2] == target[2] &&
                initial[3] == target[3] && initial[4] == target[4])
            {
                minOperations = step;
                return;
            }

            // use bfs
        }

        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            initial = new int[5];
            for (int i = 0; i < firstLine.Length; i++)
            {
                initial[i] = firstLine[i] - '0';
            }

            string secondLine = Console.ReadLine();
            target = new int[5];
            for (int i = 0; i < firstLine.Length; i++)
            {
                target[i] = secondLine[i] - '0';
            }

            used = new bool[5];
            forbidden = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                forbidden.Add(Console.ReadLine());
            }


        }
    }
}
