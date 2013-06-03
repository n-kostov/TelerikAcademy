using System;

class UnicodeCharactersLiteral
{
    static void Main()
    {
        string text = "Hi!";
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write("\\u{0:x4}", (int)text[i]);
        }
        Console.WriteLine();
    }
}

