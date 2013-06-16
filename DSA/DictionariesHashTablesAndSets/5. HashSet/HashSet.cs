using System.Collections.Generic;
using _4.HashTable;

namespace _5.HashSet
{
    public class HashSet<T> : IEnumerable<KeyValuePair<T, T>>
    {
        private HashTable<T, T> set;

        public HashSet()
        {
            this.set = new HashTable<T, T>();
        }

        public int Count
        {
            get
            {
                return this.set.Count;
            }
        }

        public void Add(T value)
        {
            this.set.Add(value, value);
        }

        public T Find(T value)
        {
            return this.set.Find(value);
        }

        public bool Remove(T value)
        {
            return this.set.Remove(value);
        }

        public void Clear()
        {
            this.set.Clear();
        }

        public void Union(HashSet<T> second)
        {
            foreach (var item in second)
            {
                this.set.Remove(item.Key);
                this.set.Add(item.Key, item.Value);
            }
        }

        public void Intersect(HashSet<T> second)
        {
            HashTable<T, T> newTable = new HashTable<T, T>();
            foreach (var item in second)
            {
                if (this.set.Remove(item.Key))
                {
                    newTable.Add(item.Key, item.Value);
                }
            }

            this.set = newTable;
        }

        public IEnumerator<KeyValuePair<T, T>> GetEnumerator()
        {
            foreach (var item in this.set)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
