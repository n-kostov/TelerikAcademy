namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EventsManager : IEventsManager
    {
        private readonly List<Event> eventsList = new List<Event>();

        public void AddEvent(Event eventItem)
        {
            this.eventsList.Add(eventItem);
        }

        public int DeleteEventsByTitle(string title)
        {
            return this.eventsList.RemoveAll(
                eventItem =>
                    eventItem.Title.ToLowerInvariant() == title.ToLowerInvariant());
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var eventsList =
                from eventItem in this.eventsList
                where eventItem.Date >= date
                orderby eventItem.Date, eventItem.Title, eventItem.Location
                select eventItem;

            return eventsList.Take(count);
        }
    }
}
