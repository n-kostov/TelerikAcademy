namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.Sort(0, collection.Count - 1, collection);
        }

        private void Sort(int left, int right, IList<T> collection)
        {
            if (left >= right)
            {
                return;
            }

            int i = left;
            int j = right;
            int pivot = (right + left) / 2;

            while (i < j)
            {
                while (collection[i].CompareTo(collection[pivot]) < 0)
                {
                    i++;
                }

                while (collection[j].CompareTo(collection[pivot]) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T oldValue = collection[i];
                    collection[i] = collection[j];
                    collection[j] = oldValue;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                this.Sort(left, j, collection);
            }

            if (right > i)
            {
                this.Sort(i, right, collection);
            }
        }
    }
}
