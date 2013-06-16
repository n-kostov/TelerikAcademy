using System;
using System.Collections.Generic;

namespace _4.HashTable
{
    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const double Threshold = 0.75;
        private int capacity;
        private int load;
        private LinkedList<KeyValuePair<K, T>>[] table;

        public HashTable()
        {
            this.load = 0;
            this.capacity = 16;
            this.table = new LinkedList<KeyValuePair<K, T>>[this.capacity];
            for (int i = 0; i < this.capacity; i++)
            {
                this.table[i] = new LinkedList<KeyValuePair<K, T>>();
            }
        }

        public int Count
        {
            get
            {
                return this.GetCount();
            }
        }

        public K[] Keys
        {
            get
            {
                return this.GetKeys();
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }

            set
            {
                int index = key.GetHashCode() % this.capacity;
                var first = this.table[index].First;
                while (first != null)
                {
                    if (first.Value.Key.Equals(key))
                    {
                        this.table[index].Remove(first);
                        this.table[index].AddLast(new KeyValuePair<K, T>(key, value));
                        return;
                    }

                    first = first.Next;
                }

                this.table[index].AddLast(new KeyValuePair<K, T>(key, value));
            }
        }

        public void Add(K key, T value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "The key cannot be null!");
            }

            int index = key.GetHashCode() % this.capacity;
            if (this.table[index] != null && !this.IsUnique(key, this.table[index]))
            {
                throw new ArgumentException("This key already exist in the hash table!", "key");
            }

            this.table[index].AddLast(new KeyValuePair<K, T>(key, value));
            this.load++;
            if (this.load / this.capacity > Threshold)
            {
                this.Resize();
            }
        }

        public T Find(K key)
        {
            int index = key.GetHashCode() % this.capacity;
            var first = this.table[index].First;
            while (first != null)
            {
                if (first.Value.Key.Equals(key))
                {
                    return first.Value.Value;
                }

                first = first.Next;
            }

            throw new ArgumentException("Cannot find the specified key in the hash table!", "key");
        }

        public bool Remove(K key)
        {
            int index = key.GetHashCode() % this.capacity;
            var first = this.table[index].First;
            while (first != null)
            {
                if (first.Value.Key.Equals(key))
                {
                    this.table[index].Remove(first.Value);
                    return true;
                }

                first = first.Next;
            }

            return false;
        }

        public void Clear()
        {
            foreach (var list in this.table)
            {
                while (list.Last != null)
                {
                    list.RemoveLast();
                }
            }
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.table)
            {
                foreach (var pair in list)
                {
                    yield return pair;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private K[] GetKeys()
        {
            K[] keys = new K[this.GetCount()];
            int i = 0;
            foreach (var list in this.table)
            {
                var first = list.First;
                while (first != null)
                {
                    keys[i] = first.Value.Key;
                    i++;
                    first = first.Next;
                }
            }

            return keys;
        }

        private int GetCount()
        {
            int count = 0;
            foreach (var list in this.table)
            {
                count += list.Count;
            }

            return count;
        }

        private bool IsUnique(K key, LinkedList<KeyValuePair<K, T>> list)
        {
            var first = list.First;
            while (first != null)
            {
                if (first.Value.Key.Equals(key))
                {
                    return false;
                }

                first = first.Next;
            }

            return true;
        }

        private void Resize()
        {
            this.capacity *= 2;
            LinkedList<KeyValuePair<K, T>>[] newTable = new LinkedList<KeyValuePair<K, T>>[this.capacity];
            this.PopulateTable(newTable);
            this.table = newTable;
        }

        private void PopulateTable(LinkedList<KeyValuePair<K, T>>[] table)
        {
            foreach (var node in this.table)
            {
                var first = node.First;
                while (first != null)
                {
                    int index = first.Value.Key.GetHashCode() % this.capacity;
                    table[index].AddLast(first.Value);
                    first = first.Next;
                }
            }
        }
    }
}
