using System;
using System.Text;

class TwentyCharactersString
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        string str = Console.ReadLine();
        sb.Append(str.Substring(0));
        if (sb.Length >= 20)
        {
            sb.Remove(20, sb.Length - 20);
        }
        else
        {
            for (int i = sb.Length; i < 20; i++)
            {
                sb.Append('*');
            }
        }
        Console.WriteLine(sb);
    }
}

