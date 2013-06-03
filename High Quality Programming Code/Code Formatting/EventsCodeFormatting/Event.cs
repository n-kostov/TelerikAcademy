using System;
using System.Text;

internal class Event : IComparable
{
    private DateTime date;
    private string title;
    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    public int CompareTo(object obj)
    {
        Event other = obj as Event;
        int comparisonByDate = this.date.CompareTo(other.date);
        int comparisonByTitle = this.title.CompareTo(other.title);

        int comparisonByLocation = this.location.CompareTo(other.location);
        if (comparisonByDate == 0)
        {
            if (comparisonByTitle == 0)
            {
                return comparisonByLocation;
            }
            else
            {
                return comparisonByTitle;
            }
        }
        else
        {
            return comparisonByDate;
        }
    }

    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();
        toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + this.title);

        if (this.location != null && this.location != string.Empty)
        {
            toString.Append(" | " + this.location);
        }

        return toString.ToString();
    }
}
