namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (item.CompareTo(this.items[i]) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int left = 0;
            int right = this.items.Count - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                int comparison = item.CompareTo(this.items[middle]);
                if (comparison < 0)
                {
                    right = middle - 1;
                }
                else if (comparison > 0)
                {
                    left = middle + 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            // Shuffling by sorting by a random number-- in this case, a GUID.
            // It is slow n * log(n) to sort + n to put items back in the list
            // it can be optimized to be n * log(n) if we sort directly in the list
            // var shuffledItems = this.items.OrderBy(a => Guid.NewGuid());
            // int i = 0;
            // foreach (var item in shuffledItems)
            // {
            //    this.items[i] = item;
            //    i++;
            // }

            // Fisher–Yates shuffle algorithm
            // n swaps
            Random randomNumberGenerator = new Random();
            for (int i = 0; i < this.items.Count; i++)
            {
                int randomIndex = i + randomNumberGenerator.Next(0, this.items.Count - i);
                T oldValue = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = oldValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
