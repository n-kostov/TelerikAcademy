namespace _11.LinkedList
{
    public class ListItem<T>
    {
        public ListItem(T value, ListItem<T> next)
        {
            this.Value = value;
            this.NextItem = next;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }
    }
}
