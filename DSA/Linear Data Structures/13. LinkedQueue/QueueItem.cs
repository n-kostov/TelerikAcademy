namespace _13.LinkedQueue
{
    public class QueueItem<T>
    {
        public QueueItem(T value, QueueItem<T> next)
        {
            this.Value = value;
            this.NextItem = next;
        }

        public T Value { get; set; }

        public QueueItem<T> NextItem { get; set; }
    }
}
