namespace _1.Salaries
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int c;
        private static char[,] graph;
        private static long[] salaries;
        private static bool[] used;

        public static void Main(string[] args)
        {
            c = int.Parse(Console.ReadLine());

            graph = new char[c, c];
            salaries = new long[c];
            used = new bool[c];

            for (int i = 0; i < c; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < c; j++)
                {
                    graph[i, j] = line[j];
                }
            }

            for (int i = 0; i < c; i++)
            {
                if (!used[i])
                {
                    DFS(i);
                }
            }

            Console.WriteLine(salaries.Sum());
        }

        private static void DFS(int index)
        {
            used[index] = true;
            bool hasChildren = false;
            for (int i = 0; i < c; i++)
            {
                if (graph[index, i] == 'Y')
                {
                    hasChildren = true;
                    if (!used[i])
                    {
                        DFS(i);
                    }

                    salaries[index] += salaries[i];
                }
            }

            if (!hasChildren)
            {
                salaries[index] = 1;
            }
        }
    }
}
