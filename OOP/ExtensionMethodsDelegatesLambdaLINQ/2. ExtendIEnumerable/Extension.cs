using System;
using System.Collections.Generic;

namespace _2.ExtendIEnumerable
{
    public static class Extension
    {
        public static decimal Sum<T>(this IEnumerable<T> collection)
        {
            decimal result = 0;
            foreach (var item in collection)
            {
                result += Convert.ToDecimal(item);
            }
            return result;
        }

        public static decimal Product<T>(this IEnumerable<T> collection)
        {
            decimal result = 1;
            foreach (var item in collection)
            {
                result *= Convert.ToDecimal(item);
            }
            return result;
        }

        public static decimal Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            decimal min = decimal.MaxValue;

            foreach (var item in collection)
            {
                if (Convert.ToDecimal(item) < min)
                {
                    min = Convert.ToDecimal(item);
                }
            }

            return min;
        }

        public static decimal Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            decimal max = decimal.MinValue;

            foreach (var item in collection)
            {
                if (Convert.ToDecimal(item) > max)
                {
                    max = Convert.ToDecimal(item);
                }
            }

            return max;
        }

        public static decimal Average<T>(this IEnumerable<T> collection)
        {
            decimal sum = 0;
            int count = 0;
            foreach (var item in collection)
            {
                sum += Convert.ToDecimal(item);
                count++;
            }
            return sum / count;
        }
    }
}
