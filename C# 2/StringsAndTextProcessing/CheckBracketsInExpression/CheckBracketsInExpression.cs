using System;
using System.Collections.Generic;

class CheckBracketsInExpression
{
    static void Main()
    {
        string exxpression = "(a+5)(b+5)(";
        Stack<char> brackets = new Stack<char>();
        bool correct = true;
        foreach (var item in exxpression)
        {
            if (item == '(')
            {
                brackets.Push(item);
            }
            if (item == ')')
            {
                if (brackets.Count != 0)
                {
                    brackets.Pop();
                }
                else
                {
                    correct = false;
                    break;
                }
            }
        }
        if (brackets.Count != 0)
        {
            correct = false;
        }
        if (correct)
        {
            Console.WriteLine("{0} is correct expression", exxpression);
        } 
        else
        {
            Console.WriteLine("{0} is not correct expression", exxpression);
        }
    }
}

