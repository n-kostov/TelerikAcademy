using System;
using System.Text;
using Wintellect.PowerCollections;

internal class Program
{
    private static StringBuilder output = new StringBuilder();
    private static EventHolder events = new EventHolder();

    public static void Main(string[] args)
    {
        while (ExecuteNextCommand())
        {
        }

        Console.WriteLine(output);
    }

    private static bool ExecuteNextCommand()
    {
        string command = Console.ReadLine();

        if (command[0] == 'A')
        {
            AddEvent(command);
            return true;
        }

        if (command[0] == 'D')
        {
            DeleteEvents(command);
            return true;
        }

        if (command[0] == 'L')
        {
            ListEvents(command);
            return true;
        }

        if (command[0] == 'E')
        {
            return false;
        }

        return false;
    }

    private static void ListEvents(string command)
    {
        int pipeIndex = command.IndexOf('|');
        DateTime date = GetDate(command, "ListEvents");
        string countstring = command.Substring(pipeIndex + 1);
        int count = int.Parse(countstring);
        events.ListEvents(date, count);
    }

    private static void DeleteEvents(string command)
    {
        string title = command.Substring("DeleteEvents".Length + 1);
        events.DeleteEvents(title);
    }

    private static void AddEvent(string command)
    {
        DateTime date;
        string title;
        string location;

        GetParameters(command, "AddEvent", out date, out title, out location);
        events.AddEvent(date, title, location);
    }

    private static void GetParameters(
        string commandForExecution,
        string commandType,
        out DateTime dateAndTime,
        out string eventTitle,
        out string eventLocation)
    {
        dateAndTime = GetDate(commandForExecution, commandType);
        int firstPipeIndex = commandForExecution.IndexOf('|');
        int lastPipeIndex = commandForExecution.LastIndexOf('|');

        if (firstPipeIndex == lastPipeIndex)
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
            eventLocation = string.Empty;
        }
        else
        {
            eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
            eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
        }
    }

    private static DateTime GetDate(string command, string commandType)
    {
        DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
        return date;
    }

    // this classes could be put in their own files but should be rewritten first
    private static class Messages
    {
        public static void EventAdded()
        {
            output.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }

    private class EventHolder
    {
        private MultiDictionary<string, Event> listByTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> listByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
            this.listByTitle.Add(title.ToLower(), newEvent);
            this.listByDate.Add(newEvent);
            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removedEvents = 0;

            foreach (var eventToRemove in this.listByTitle[title])
            {
                removedEvents++;
                this.listByDate.Remove(eventToRemove);
            }

            this.listByTitle.Remove(title);
            Messages.EventDeleted(removedEvents);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.listByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showedEvents = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showedEvents == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showedEvents++;
            }

            if (showedEvents == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}