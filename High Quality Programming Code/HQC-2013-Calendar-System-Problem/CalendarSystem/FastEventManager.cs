namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class FastEventsManager : IEventsManager
    {
        private readonly MultiDictionary<string, Event> eventsByTitle =
            new MultiDictionary<string, Event>(true);

        private readonly OrderedMultiDictionary<DateTime, Event> eventsByDate =
            new OrderedMultiDictionary<DateTime, Event>(true);

        public void AddEvent(Event eventItem)
        {
            string eventTitleLowerCase = eventItem.Title.ToLowerInvariant();

            this.eventsByTitle.Add(eventTitleLowerCase, eventItem);
            this.eventsByDate.Add(eventItem.Date, eventItem);
        }

        public int DeleteEventsByTitle(string title)
        {
            string lowerCaseTitle = title.ToLowerInvariant();

            var eventsToDelete = this.eventsByTitle[lowerCaseTitle];
            int count = eventsToDelete.Count;

            foreach (var eventItem in eventsToDelete)
            {
                this.eventsByDate.Remove(eventItem.Date, eventItem);
            }

            this.eventsByTitle.Remove(lowerCaseTitle);

            return count;
        }

        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            return this.eventsByDate
                .RangeFrom(date, true).Values
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Title)
                .ThenBy(x => x.Location)
                .Take(count);
        }
    }
}
