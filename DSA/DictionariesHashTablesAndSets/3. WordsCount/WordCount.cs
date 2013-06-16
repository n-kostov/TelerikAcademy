using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordsCount
{
    public class WordCount
    {
        public static void Main(string[] args)
        {
            using (var sr = new StreamReader("words.txt"))
            {
                IDictionary<string, int> wordsCount = new Dictionary<string, int>();
                string[] words = GetWords(sr.ReadToEnd());

                for (int i = 0; i < words.Length; i++)
                {
                    string word = words[i].ToLower();
                    if (wordsCount.ContainsKey(word))
                    {
                        wordsCount[word]++;
                    }
                    else
                    {
                        wordsCount[word] = 1;
                    }
                }

                var wordsOrderedByOccurrences = wordsCount.OrderBy(x => x.Value);

                foreach (var word in wordsOrderedByOccurrences)
                {
                    Console.WriteLine("{0} => {1} times", word.Key, word.Value);
                }
            }
        }

        public static string[] GetWords(string text)
        {
            char[] delims = { ' ', ',', '?', '!', '.', ';', '–' };
            string[] words = text.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
    }
}
