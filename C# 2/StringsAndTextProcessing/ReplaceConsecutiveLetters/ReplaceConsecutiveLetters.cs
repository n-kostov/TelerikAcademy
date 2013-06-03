using System.Text;
using System;

class ReplaceConsecutiveLetters
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaa";
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length - 1; i++)
        {
            sb.Append(text[i]);
            for (int j = i + 1; j < text.Length; j++)
            {
                if (text[i] == text[j])
                {
                    continue;
                }
                else
                {
                    i = j - 1;
                    break;
                }
            }
        }
        Console.WriteLine(sb);
    }
}

