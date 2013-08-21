namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            int firstArraySize = collection.Count / 2;
            int secondArraySize = collection.Count - firstArraySize;
            List<T> firstArray = collection.ToList().GetRange(0, firstArraySize);
            List<T> secondArray = collection.ToList().GetRange(firstArraySize, secondArraySize);
            this.Sort(firstArray);
            this.Sort(secondArray);

            int i = 0;
            int j = 0;
            int index = 0;
            while (i < firstArraySize && j < secondArraySize)
            {
                if (firstArray[i].CompareTo(secondArray[j]) <= 0)
                {
                    collection[index] = firstArray[i];
                    i++;
                }
                else
                {
                    collection[index] = secondArray[j];
                    j++;
                }

                index++;
            }

            while (i < firstArraySize)
            {
                collection[index] = firstArray[i];
                i++;
                index++;
            }

            while (j < secondArraySize)
            {
                collection[index] = secondArray[j];
                j++;
                index++;
            }
        }
    }
}
