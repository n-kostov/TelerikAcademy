using System;
using System.Text;

namespace _5_7_GenericList
{
    public class GenericList<T> where T : IComparable<T>
    {
        private int capacity;
        private int count;
        private T[] array;

        public GenericList()
        {
            capacity = 16;
            count = 0;
            array = new T[capacity];
        }

        public GenericList(int capacity)
        {
            this.capacity = capacity;
            count = 0;
            array = new T[this.capacity];
        }

        public void Add(T element)
        {
            array[count++] = element;
            ResizeList();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > count - 1)
            {
                throw new IndexOutOfRangeException("Cannot access elements out of the list");
            }
            else
            {
                return array[index];
            }
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine("Cannot access elements out of the list");
                }
                else
                {
                    array[index] = value;
                }
            }
        }


        //public T GetAt(int index)
        //{
        //    if (index < 0 || index > count - 1)
        //    {
        //        throw new IndexOutOfRangeException("Cannot access elements out of the list");
        //    }
        //    else
        //    {
        //        return array[index];
        //    }
        //}

        public void Remove(int index)
        {
            if (index < 0 || index > count - 1)
            {
                Console.WriteLine("Cannot access elements out of the list");
            }
            else if (count == 0)
            {
                Console.WriteLine("Cannot delete elements in empty list");
            }
            else
            {
                for (int i = index; i < count; i++)
                {
                    array[i] = array[i + 1];
                }
                count--;
            }
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine("Cannot access elements out of the list");
            }
            else
            {

                count++;
                for (int i = count - 1; i > index; i--)
                {
                    array[i] = array[i - 1];
                }
                array[index] = element;
            }
            ResizeList();
        }

        public void Clear()
        {
            while (count > 0)
            {
                Remove(count - 1);
            }
        }

        public int Find(T element)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i].CompareTo(element) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('{');
            for (int i = 0; i < count - 1; i++)
            {
                sb.Append(array[i]);
                sb.Append(", ");
            }
            sb.Append(array[count - 1]);
            sb.Append('}');
            return sb.ToString();
        }

        private void ResizeList()
        {
            if (count == capacity)
            {
                capacity *= 2;
                T[] tempArray = new T[capacity];
                for (int i = 0; i < count; i++)
                {
                    tempArray[i] = array[i];
                }
                array = new T[capacity];
                array = tempArray;
            }
        }

        public T Min()
        {
            T min = array[0];
            for (int i = 1; i < count; i++)
            {
                if (array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public T Max()
        {
            T max = array[0];
            for (int i = 1; i < count; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }
}
