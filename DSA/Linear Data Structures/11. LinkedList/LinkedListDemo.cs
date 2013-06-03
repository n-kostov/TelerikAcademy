using System;

namespace _11.LinkedList
{
    public class LinkedListDemo
    {
        public static void PrintList(LinkedList<string> list)
        {
            ListItem<string> current = list.First;
            while (current.NextItem != null)
            {
                Console.Write(current.Value + ", ");
                current = current.NextItem;
            }

            Console.WriteLine(current.Value);
        }

        public static void Main(string[] args)
        {
            LinkedList<string> list =
    new LinkedList<string>();
            list.AddFirst("1");
            list.AddLast("5");
            list.AddAfter(list.First, "2");
            list.AddBefore(list.Last, "3");
            list.AddBefore(list.Last, "4");
            list.Remove(list.First.NextItem);

            PrintList(list);
        }
    }
}
