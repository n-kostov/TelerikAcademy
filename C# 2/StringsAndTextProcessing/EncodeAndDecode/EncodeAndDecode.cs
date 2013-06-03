using System;
using System.Text;

class EncodeAndDecode
{
    static void Main()
    {
        Console.Write("word = ");
        string word = Console.ReadLine();
        Console.Write("cipher = ");
        string cipher = Console.ReadLine();
        StringBuilder sb = new StringBuilder(word.Length);
        int j = 0;
        for (int i = 0; i < word.Length; i++)
        {
            sb.Append((char)(word[i] ^ cipher[j]));
            if (j < cipher.Length - 1)
            {
                j++;
            }
            else
            {
                j = 0;
            }
        }
        Console.WriteLine(sb);
    }
}

