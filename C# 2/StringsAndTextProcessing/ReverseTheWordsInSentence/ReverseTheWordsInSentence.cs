using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ReverseTheWordsInSentence
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        char endOfSentence = sentence[sentence.Length - 1];
        char[] delimiters = { ' ', ',', endOfSentence};
        string[] words = sentence.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        Queue<string> queue = new Queue<string>();
        for (int i = 0; i < sentence.Length; i++)
        {
            if (char.IsWhiteSpace(sentence[i]))
            {
                queue.Enqueue(sentence[i].ToString());
            }
            if (sentence[i] == ',')
            {
                queue.Enqueue(sentence[i] + " ");
                i++;
            }
        }
        queue.Enqueue(endOfSentence.ToString());
        StringBuilder sb = new StringBuilder();
        for (int i = words.Length - 1; i >= 0; i--)
        {
            sb.Append(words[i]);
            sb.Append(queue.Peek());
            queue.Dequeue();
        }
        Console.WriteLine(sb);
    }
}

