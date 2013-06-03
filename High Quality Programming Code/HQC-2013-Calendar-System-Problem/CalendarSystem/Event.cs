namespace CalendarSystem
{
    using System;

    public class Event : IComparable<Event>
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            string format = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            if (this.Location != null)
            {
                format += " | {2}";
            }

            string result = string.Format(format, this.Date, this.Title, this.Location);
            return result;
        }

        public int CompareTo(Event x)
        {
            int result = DateTime.Compare(this.Date, x.Date);

            if (result == 0)
            {
                result = string.Compare(this.Title, x.Title, StringComparison.Ordinal);
            }

            if (result == 0)
            {
                result = string.Compare(this.Location, x.Location, StringComparison.Ordinal);
            }

            return result;
        }
    }
}