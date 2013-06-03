using System;

class AlphabetArray
{
    static void Main()
    {
        char[] alphabet = new char[26];
        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabet[i] = (char)('A' + i);
        }
        Console.Write("word = ");
        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {

            int start = 0;
            int end = alphabet.Length - 1;
            char item = word[i];
            if (item >= 'a' && item <= 'z')
            {
                item = (char)(item - 32);
            }
            while (start <= end)
            {

                int middle = (start + end) / 2;
                if (alphabet[middle] < item)
                {
                    start = middle + 1;
                }
                else if (alphabet[middle] > item)
                {
                    end = middle - 1;
                }
                else
                {
                    Console.WriteLine(middle);
                    break;
                }
            }


        }
    }
}

