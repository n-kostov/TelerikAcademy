using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DSlices
{
    class Program
    {
        static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            string[] dims = dimensions.Split(' ');
            byte w = byte.Parse(dims[0]);
            byte h = byte.Parse(dims[1]);
            byte d = byte.Parse(dims[2]);
            int[, ,] grid = new int[d, h, w];
            for (int i = 0; i < h; i++)
            {
                string line = Console.ReadLine();
                string[] floors = line.Split(new string[] { " | " }, StringSplitOptions.None);
                for (int j = 0; j < floors.Length; j++)
                {
                    string[] cols = floors[j].Split(' ');
                    for (int k = 0; k < cols.Length; k++)
                    {
                        grid[j, i, k] = int.Parse(cols[k]);
                    }
                }
            }

            int numberOfSlices = 0;
            int sumAll = 0;
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    for (int l = 0; l < w; l++)
                    {
                        sumAll += grid[i, j, l];
                    }
                }
            }

            //  width
            int s = 0;
            for (int i = 0; i < w - 1; i++)
            {
                int sum = 0;
                for (int j = 0; j < d; j++)
                {
                    for (int k = 0; k < h; k++)
                    {
                        sum += grid[j, k, i];
                    }
                }
                s += sum;
                if (s == sumAll - s)
                {
                    numberOfSlices++;
                }
            }

            //  height
            s = 0;
            for (int i = 0; i < h - 1; i++)
            {
                int sum = 0;
                for (int j = 0; j < d; j++)
                {
                    for (int k = 0; k < w; k++)
                    {
                        sum += grid[j, i, k];
                    }
                }
                s += sum;
                if (s == sumAll - s)
                {
                    numberOfSlices++;
                }
            }

            //  depth
            s = 0;
            for (int i = 0; i < d - 1; i++)
            {
                int sum = 0;
                for (int j = 0; j < h; j++)
                {
                    for (int k = 0; k < w; k++)
                    {
                        sum += grid[i, j, k];
                    }
                }
                s += sum;
                if (s == sumAll - s)
                {
                    numberOfSlices++;
                }
            }


            Console.WriteLine(numberOfSlices);
        }
    }

}
