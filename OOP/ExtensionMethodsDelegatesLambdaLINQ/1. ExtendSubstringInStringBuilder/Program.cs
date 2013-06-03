using System;
using System.Text;

//  1.Implement an extension method Substring(int index, int length) for the class StringBuilder
//  that returns new StringBuilder and has the same functionality as Substring in the class String.

namespace _1.ExtendSubstringInStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("qwerty is not a strong password");
            Console.WriteLine(stringBuilder.Substring(7,2));
        }
    }
}
