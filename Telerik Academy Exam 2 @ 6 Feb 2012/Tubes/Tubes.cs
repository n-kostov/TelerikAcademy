using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Tubs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            long sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i];
            }
            int size = (int)(sum / m);
            if (size == 0)
            {
                Console.WriteLine(-1);
                return;
            }
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                count += array[i] / size;
            }
            if (count == m)
            {
                Console.WriteLine(size);
                return;
            } 
            else
            {
                int down = 0;
                int up = int.MaxValue;
                do 
                {
                    count = 0;
                    int middle = (down + up) / 2;
                    for (int i = 0; i < n; i++)
                    {
                        count += array[i] / middle;
                    }
                    if (count >= m)
                    {
                        down = middle + 1;
                        size = middle;
                    } 
                    else
                    {
                        up = middle - 1;
                    }
                } while (down <= up);
            }

            //int k = 0;
            //bool up = true;
            //do
            //{
            //    if (size == 0)
            //    {
            //        break;
            //    }
            //    count = 0;
            //    for (int i = 0; i < n; i++)
            //    {
            //        count += array[i] / size;
            //    }
            //    if (count == m)
            //    {
            //        if (up)
            //        {
            //            do
            //            {
            //                size++;
            //                count = 0;
            //                for (int i = 0; i < n; i++)
            //                {
            //                    count += array[i] / size;
            //                }
            //            } while (count == m);
            //            size--;
            //            break;
            //        }
            //        else
            //        {
            //            break;
            //        }

            //    }
            //    else
            //    {
            //        int s = 0;
            //        for (int i = 0; i <= k; i++)
            //        {
            //            s += array[i] / size;
            //        }
            //        int s1 = 0;
            //        for (int i = k + 1; i < n; i++)
            //        {
            //            s1 += array[i];
            //        }
            //        if (size > (int)Math.Ceiling(s1 / (float)(m - s)))
            //        {
            //            size = (int)Math.Ceiling(s1 / (float)(m - s));
            //        }
            //        if (k < n - 1)
            //        {
            //            k++;
            //        }
            //    }
            //} while (count != m);

            Console.WriteLine(size);
        }
    }
}
