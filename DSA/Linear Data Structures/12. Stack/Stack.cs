using System;

namespace _12.Stack
{
    public class Stack<T>
    {
        private T[] array;
        private int top;

        public Stack()
            : this(8)
        {
        }

        public Stack(int arraySize)
        {
            this.top = -1;
            this.array = new T[arraySize];
        }

        public void Push(T value)
        {
            if (this.top == this.array.Length - 1)
            {
                this.Extend();
            }

            this.top++;
            this.array[this.top] = value;
        }

        public T Pop()
        {
            if (this.top <= 0)
            {
                throw new InvalidOperationException("Cannot pop elements from empty stack!");
            }

            this.top--;
            return this.array[this.top];
        }

        public T Peek()
        {
            if (this.top < 0)
            {
                throw new InvalidOperationException("Cannot peek elements from empty stack!");
            }

            return this.array[this.top];
        }

        private void Extend()
        {
            T[] newArray = new T[this.array.Length * 2];
            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }
    }
}
