using System.Text;
using System;

class ReverseAString
{
    static void Main()
    {
        Console.Write("str = ");
        string str = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            sb.Append(str[i]);
        }
        Console.WriteLine(sb);
    }
}

