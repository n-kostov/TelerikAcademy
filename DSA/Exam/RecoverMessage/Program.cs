using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverMessage
{
    class Program
    {
        private static Dictionary<char, SortedSet<char>> graph = new Dictionary<char, SortedSet<char>>();

        //public static bool[] visitedElements;

        //public void Dfs(int startIndex)
        //{
        //    visitedElements[startIndex] = true;

        //    for (int k = 0; k < this.count; k++)
        //    {
        //        if ((this.edges[startIndex, k] == 1) && (visitedElements[k] == false))
        //        {
        //            Dfs(k);
        //        }
        //    }

        //    if (startIndex >= 0 && startIndex <= 25)
        //    {
        //        sortedElements.Add((char)(startIndex + 'a'));
        //    }
        //    else
        //    {
        //        sortedElements.Add((char)(startIndex + 'A'));
        //    }
        //}

        public static void Dfs()
        {
            List<char> list = new List<char>();
            SortedSet<char> set = FindAllWithNoParents();
            while (set.Count > 0)
            {
                char node = set.First();
                set.Remove(node);
                list.Add(node);
                if (graph.ContainsKey(node))
                {
                    foreach (var item in graph[node])
                    {
                        char current = item;
                        if (!HasParent(current, node))
                        {
                            set.Add(current);
                        }
                    }

                    graph[node].Clear();
                }
            }

            ShowSort(list);
        }


        //public void TestDfs()
        //{
        //    for (int i = 0; i < this.count; i++)
        //    {
        //        if (this.visitedElements[i] == false)
        //        {
        //            Dfs(i);
        //        }
        //    }
        //}

        public static void ShowSort(List<char> sortedElements)
        {
            //sortedElements.Reverse();

            for (int i = 0; i < sortedElements.Count; i++)
            {
                Console.Write("{0}", sortedElements[i]);
            }

            Console.WriteLine();
        }

        public static bool HasParent(char node, char parent)
        {
            bool hasParant = false;
            foreach (var item in graph.Keys)
            {
                if (item != node && item != parent)
                {
                    if (graph[item].Contains(node))
                    {
                        hasParant = true;
                        break;
                    }
                }
            }

            return hasParant;
        }

        public static SortedSet<char> FindAllWithNoParents()
        {
            SortedSet<char> set = new SortedSet<char>();
            foreach (var key in graph.Keys)
            {
                bool hasParant = false;
                foreach (var item in graph.Keys)
                {
                    if (key != item)
                    {
                        if (graph[item].Contains(key))
                        {
                            hasParant = true;
                            break;
                        }
                    }
                }

                if (!hasParant)
                {
                    set.Add(key);
                }
            }

            return set;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < line.Length - 1; j++)
                {
                    if (!graph.ContainsKey(line[j]))
                    {
                        graph[line[j]] = new SortedSet<char>();
                    }

                    graph[line[j]].Add(line[j + 1]);
                }

                if (!graph.ContainsKey(line[line.Length - 1]))
                {
                    graph[line[line.Length - 1]] = new SortedSet<char>();
                }
            }

            Dfs();
        }
    }
}
