using System;

namespace _12.Stack
{
    public class StackDemo
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
        }
    }
}
