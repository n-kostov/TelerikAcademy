//-----------------------------------------------------------------------
// <copyright file="IEventsManager.cs" company="MyCompany">
//     Copyright MyCompany. All rights reserved.
// </copyright>
// <author>Me</author>
//-----------------------------------------------------------------------
namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Event manager containing events.
    /// </summary>
    public interface IEventsManager
    {
        /// <summary>
        /// Adds event <paramref name="eventToAdd"/> to the manager.
        /// </summary>
        /// <param name="eventToAdd">The event which we want to add to the manager.</param>
        void AddEvent(Event eventToAdd);

        /// <summary>
        /// Deletes all events that have title <paramref name="title"/>.
        /// </summary>
        /// <param name="title">The title of events to delete.</param>
        /// <returns>Returns the number of deleted events.</returns>
        int DeleteEventsByTitle(string title);

        /// <summary>
        /// Gets all events that have date equal or greater than <paramref name="date"/>
        /// but no more than <paramref name="count"/> events if available.
        /// </summary>
        /// <param name="date">The date to look for in the events.</param>
        /// <param name="count">The number of events to get.</param>
        /// <returns>Returns collection of all events that have date equal or greater 
        /// than <paramref name="date"/>
        /// but no more than <paramref name="count"/> events if available.
        /// </returns>
        IEnumerable<Event> ListEvents(DateTime date, int count);
    }
}
