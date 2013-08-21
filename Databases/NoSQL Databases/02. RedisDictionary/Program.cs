using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RedisDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            AddWord("fish", "riba");
            AddWord("ghost", "duh");
            ListAllWords();
            Translate("fish");
        }

        private static void ListAllWords()
        {
            var list = RedisDbActions.GetKeysAndValues();

            foreach (var item in list)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }

        static void AddWord(string word, string translation)
        {
            RedisDbActions.StoreInHash(word, translation);
        }

        private static void Translate(string word)
        {
            Console.WriteLine("Translation: {0}", RedisDbActions.GetValue(word));
        }
    }
}
