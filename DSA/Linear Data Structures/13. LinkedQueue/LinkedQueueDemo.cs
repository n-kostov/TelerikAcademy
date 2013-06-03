using System;

namespace _13.LinkedQueue
{
    public class LinkedQueueDemo
    {
        public static void Main(string[] args)
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            Console.WriteLine("Queue count without elements: " + queue.Count);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine("Queue count with 3 elements: " + queue.Count);
            Console.WriteLine("The front of the queue was: " + queue.Dequeue());
            Console.WriteLine("The front of the queue now is: " + queue.Peek());
        }
    }
}
