using System;
using System.Collections.Generic;

namespace _10.ShortestSequenceOfOperations
{
    public class ShortestSequenceOfOperations
    {
        public static Dictionary<int, int> FindParents(int n, int m)
        {
            Dictionary<int, int> parents = new Dictionary<int, int>();
            Queue<int> workList = new Queue<int>();
            workList.Enqueue(n);
            while (true)
            {
                int currentItem = workList.Dequeue();
                int doubledCurrentItem = currentItem * 2;
                if (IsFoundInIteration(currentItem, doubledCurrentItem, m, parents, workList))
                {
                    break;
                }

                int currentItemPlusTwo = currentItem + 2;
                if (IsFoundInIteration(currentItem, currentItemPlusTwo, m, parents, workList))
                {
                    break;
                }

                int currentItemPlusOne = currentItem + 1;
                if (IsFoundInIteration(currentItem, currentItemPlusOne, m, parents, workList))
                {
                    break;
                }
            }

            return parents;
        }

        public static void PrintShortesSequenceOfOperations(Dictionary<int, int> parents, int n, int m)
        {
            Stack<int> result = new Stack<int>();
            int currentItem = m;
            while (currentItem != n)
            {
                result.Push(currentItem);
                currentItem = parents[currentItem];
            }

            result.Push(currentItem);

            while (result.Count != 0)
            {
                Console.Write(result.Pop() + " ");
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("m = ");
            int m = int.Parse(Console.ReadLine());

            Dictionary<int, int> parents = FindParents(n, m);

            PrintShortesSequenceOfOperations(parents, n, m);
        }

        private static bool IsFoundInIteration(int item, int iteratedItem, int m, Dictionary<int, int> parents, Queue<int> workList)
        {
            if (iteratedItem == m)
            {
                parents[m] = item;
                return true;
            }
            else if (iteratedItem < m && !workList.Contains(iteratedItem) && !parents.ContainsKey(iteratedItem))
            {
                workList.Enqueue(iteratedItem);
                parents[iteratedItem] = item;
            }

            return false;
        }
    }
}
