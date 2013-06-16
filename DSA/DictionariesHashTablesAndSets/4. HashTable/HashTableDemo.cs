using System;

namespace _4.HashTable
{
    public class HashTableDemo
    {
        public static void Main(string[] args)
        {
            HashTable<string, int> dictionary = new HashTable<string, int>();
            dictionary.Add("the", 1);
            dictionary.Add("p", 0);
            dictionary["zle"] = 10;
            Console.WriteLine("p = " + dictionary.Find("p"));
            dictionary.Remove("p");
            dictionary["p"] = 3;
            Console.WriteLine("p = " + dictionary["p"]);

            foreach (var pair in dictionary)
            {
                Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
            }

            Console.WriteLine("Keys: " + string.Join(", ", dictionary.Keys));

            dictionary.Clear();
        }
    }
}
