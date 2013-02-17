using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DStars
{
    class Program
    {
        static void Main()
        {
            string firstLine = Console.ReadLine();
            string[] firsts = firstLine.Split(' ');
            int[] args = new int[firsts.Length];

            for (int i = 0; i < firsts.Length; i++)
            {
                args[i] = int.Parse(firsts[i]);
            }
            //int[, ,] arr = new int[4, 2, 3];
            char[, ,] grid = new char[args[2], args[1], args[0]];
            for (int i = 0; i < args[1]; i++)
            {
                string[] rows = Console.ReadLine().Split(' ');
                for (int j = 0; j < rows.Length; j++)
                {
                    for (int k = 0; k < rows[j].Length; k++)
                    {
                        grid[j, i, k] = rows[j][k];
                    }
                }
            }

            Dictionary<char, int> dic = new Dictionary<char, int>();
            int sum = 0;
            for (int i = 1; i < args[2] - 1; i++)
            {
                for (int j = 1; j < args[1] - 1; j++)
                {
                    for (int k = 1; k < args[0] - 1; k++)
                    {
                        char color = grid[i, j, k];
                        if (grid[i - 1, j, k] == color && grid[i + 1, j, k] == color && grid[i, j - 1, k] == color && grid[i, j, k + 1] == color && grid[i, j + 1, k] == color && grid[i, j, k - 1] == color)
                        {
                            if (dic.ContainsKey(color))
                            {
                                int value;
                                dic.TryGetValue(color,out value);
                                dic[color] = value + 1;
                                sum++;
                            } 
                            else
                            {
                                dic.Add(color, 1);
                                sum++;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(sum);
            foreach (var item in dic.OrderBy(key => key.Key))
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }


    }
}
