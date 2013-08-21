using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Frames
{
    class Program
    {
        class Frame : IComparable<Frame>
        {
            public string[] Elements { get; set; }

            public Frame(string[] elements)
            {
                this.Elements = elements;
            }

            public override string ToString()
            {
                return string.Format("({0})", string.Join(", ", Elements));
            }

            public int CompareTo(Frame other)
            {
                int comparison = 0;
                int i = 0;
                for (i = 0; i < Elements.Length && i < other.Elements.Length; i++)
                {
                    comparison = this.Elements[i].CompareTo(other.Elements[i]);
                    if (comparison != 0)
                    {
                        return comparison;
                    }
                }

                if (i < Elements.Length)
                {
                    return 1;
                }
                else if (i < other.Elements.Length)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private static List<Frame> multiSet;
        private static int count = 0;
        private static SortedSet<String> result;

        static List<string> list = new List<string>();

        public static void Permute(int index, int n)
        {
            Inside(n);
            for (int i = n - 2; i >= index; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (multiSet[i] != multiSet[j])
                    {
                        var oldValue = multiSet[i];
                        multiSet[i] = multiSet[j];
                        multiSet[j] = oldValue;

                        Permute(i + 1, n);
                    }
                }

                var temp = multiSet[i];
                for (int k = i; k < n - 1; k++)
                {
                    multiSet[k] = multiSet[k + 1];
                }

                multiSet[n - 1] = temp;
            }
        }

        public static void Inside(int n)
        {
            result.Add(string.Join(" | ", multiSet));

            for (int i = 1; i < Math.Pow(2, n); i++)
            {
                int pow = 1;
                int grade = 0;
                List<int> bits = new List<int>();
                do 
                {
                    int mask = 1 << grade;
                    mask = mask & i;
                    mask = mask >> grade;
                    if (mask == 1)
                    {
                        bits.Add(grade);
                    }

                    grade++;
                    pow *= 2;
                } while (i >= pow);

                foreach (var bit in bits)
                {
                    if (multiSet[bit].Elements[0] != multiSet[bit].Elements[1])
                    {
                        var oldValue = multiSet[bit].Elements[0];
                        multiSet[bit].Elements[0] = multiSet[bit].Elements[1];
                        multiSet[bit].Elements[1] = oldValue;
                    }
                }

                result.Add(string.Join(" | ", multiSet));

                foreach (var bit in bits)
                {
                    if (multiSet[bit].Elements[0] != multiSet[bit].Elements[1])
                    {
                        var oldValue = multiSet[bit].Elements[0];
                        multiSet[bit].Elements[0] = multiSet[bit].Elements[1];
                        multiSet[bit].Elements[1] = oldValue;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            multiSet = new List<Frame>();
            for (int i = 0; i < n; i++)
            {
                string[] parameters = Console.ReadLine().Split(' ');
                multiSet.Add(new Frame(parameters));    // could be faster
            }

            multiSet.Sort();
            result = new SortedSet<string>();
            Permute(0, n);

            Console.WriteLine(result.Count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
