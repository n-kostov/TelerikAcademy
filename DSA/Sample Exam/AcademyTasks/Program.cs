using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTasks
{
    class Program
    {
        private static int variety;
        private static int[] elements;

        static int BFS()
        {
            int max = elements[0];
            int min = elements[0];
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(0, 1));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (elements[current.Item1] < min)
                {
                    min = elements[current.Item1];
                }

                if (elements[current.Item1] > max)
                {
                    max = elements[current.Item1];
                }

                if (max - min >= variety)
                {
                    return current.Item2;
                }

                if (current.Item1 + 2 < elements.Length)
                {
                    int distance1 = 0;
                    if (elements[current.Item1 + 1] < min)
                    {
                        distance1 = max - elements[current.Item1 + 1];
                    }
                    else if (elements[current.Item1 + 1] > max)
                    {
                        distance1 = elements[current.Item1 + 1] - min;
                    }

                    int distance2 = 0;
                    if (elements[current.Item1 + 2] < min)
                    {
                        distance2 = max - elements[current.Item1 + 2];
                    }
                    else if (elements[current.Item1 + 2] > max)
                    {
                        distance2 = elements[current.Item1 + 2] - min;
                    }

                    if (distance1 >= distance2)
                    {
                        queue.Enqueue(new Tuple<int, int>(current.Item1 + 1, current.Item2 + 1));
                        queue.Enqueue(new Tuple<int, int>(current.Item1 + 2, current.Item2 + 1));
                    }
                    else
                    {
                        queue.Enqueue(new Tuple<int, int>(current.Item1 + 2, current.Item2 + 1));
                    }

                }
                else if (current.Item1 + 1 < elements.Length)
                {
                    queue.Enqueue(new Tuple<int, int>(current.Item1 + 1, current.Item2 + 1));
                }
            }

            return elements.Length;
        }

        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            elements = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                elements[i] = int.Parse(numbers[i]);
            }

            variety = int.Parse(Console.ReadLine());

            Console.WriteLine(BFS());
        }
    }
}
