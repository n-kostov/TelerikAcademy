using System;

namespace _13.LinkedQueue
{
    public class LinkedQueue<T>
    {
        private QueueItem<T> front;
        private QueueItem<T> rear;
        private int count;

        public LinkedQueue()
        {
            this.count = 0;
            this.front = null;
            this.rear = null;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(T value)
        {
            QueueItem<T> newItem = new QueueItem<T>(value, null);
            if (this.rear != null)
            {
                this.rear.NextItem = newItem;
            } 
            else
            {
                this.front = newItem;
            }

            this.rear = newItem;
            this.count++;
        }

        public T Dequeue()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Cannot remove elements from empty queue!");
            }

            T value = this.front.Value;
            if (this.front == this.rear)
            {
                this.front = null;
                this.rear = null;
            } 
            else
            {
                this.front = this.front.NextItem;
            }

            this.count--;
            return value;
        }

        public T Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Cannot peek elements from empty queue!");
            }

            T value = this.front.Value;
            return value;
        }
    }
}
