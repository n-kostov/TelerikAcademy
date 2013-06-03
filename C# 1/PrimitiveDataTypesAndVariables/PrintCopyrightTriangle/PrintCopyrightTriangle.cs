using System.Text;
using System;

class PrintCopyrightTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        char copy = '\u00A9';
        Console.WriteLine("  {0}", copy);
        Console.WriteLine(" {0}{1}{2}", copy , copy , copy);
        Console.WriteLine("{0}{1}{2}{3}{4}", copy , copy , copy , copy , copy);
    }
}

