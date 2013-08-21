namespace _05.Zig_zag_Sequence
{
    using System;

    public class ZigzagSequence
    {
        private static int[] result;
        private static bool[] used;
        private static int n;
        private static int k;
        private static int count = 0;

        public static void GetOrderedVariations(int index)
        {
            if (index >= k)
            {
                count++;
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    if (index > 0)
                    {
                        if ((index % 2 == 0 && i > result[index - 1]) ||
                            (index % 2 == 1 && i < result[index - 1]))
                        {
                            used[i] = true;
                            result[index] = i;
                            GetOrderedVariations(index + 1);
                            used[i] = false;
                        }
                        else
                        {
                            if (index % 2 == 0)
                            {
                                i = result[index - 1];
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        used[i] = true;
                        result[index] = i;
                        GetOrderedVariations(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            string[] parameters = Console.ReadLine().Split(' ');
            n = int.Parse(parameters[0]);
            k = int.Parse(parameters[1]);
            result = new int[k];
            used = new bool[n];
            GetOrderedVariations(0);

            Console.WriteLine(count);
        }
    }
}
