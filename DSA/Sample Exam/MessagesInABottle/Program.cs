using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesInABottle
{
    class Program
    {
        static string message;
        static List<char> result;
        static SortedSet<string> allResults;
        static Dictionary<string, char> codes;

        static void FindSolution(int index)
        {
            if (index >= message.Length)
            {
                allResults.Add(string.Join("",result));
                return;
            }

            for (int i = index; i < message.Length; i++)
            {
                string currentWord = message.Substring(index, i + 1 - index);
                if (codes.ContainsKey(currentWord))
                {
                    result.Add(codes[currentWord]);
                    FindSolution(i + 1);
                    result.RemoveAt(result.Count - 1);
                }
            }
        }

        static void Main(string[] args)
        {
            message = Console.ReadLine();
            string cipher = Console.ReadLine();
            codes = new Dictionary<string, char>();
            result = new List<char>();
            allResults = new SortedSet<string>();

            ProccessCipher(cipher);

            FindSolution(0);

            PrintResults();
        }

        static void ProccessCipher(string cipher)
        {
            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    char letter = cipher[i];
                    int k = i;
                    do
                    {
                        i++;
                    } while (i < cipher.Length && (cipher[i] < 'A' || cipher[i] > 'Z'));

                    codes.Add(cipher.Substring(k + 1, i - k - 1), letter);
                    i--;
                }
            }
        }

        static void PrintResults()
        {
            Console.WriteLine(allResults.Count);
            foreach (var res in allResults)
            {
                Console.WriteLine(res);
            }
        }
    }
}
