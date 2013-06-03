namespace CalendarSystemTests
{
    using System;
    using System.Globalization;
    using System.Linq;
    using CalendarSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FastEventsManagerTests
    {
        [TestMethod]
        public void TestListEvents_NoEventsAtAll()
        {
            FastEventsManager eventManager = new FastEventsManager();
            var eventsList = eventManager.ListEvents(
                DateTime.ParseExact(
                    "2001-01-01T10:00:00",
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture),
                10);

            int eventsCount = eventsList.Count();

            Assert.AreEqual(0, eventsCount);
        }

        [TestMethod]
        public void TestListEvents_List1()
        {
            FastEventsManager eventManager = new FastEventsManager();
            Event eventItem = new Event();
            eventItem.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem.Title = "party";
            eventItem.Location = "nowhere";
            eventManager.AddEvent(eventItem);

            var eventsList = eventManager.ListEvents(
                DateTime.ParseExact(
                    "2001-01-01T10:00:00",
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture),
                10);

            int eventsCount = eventsList.Count();

            Assert.AreEqual(1, eventsCount);
        }

        [TestMethod]
        public void TestListEvents_ListAll()
        {
            FastEventsManager eventManager = new FastEventsManager();
            Event eventItem1 = new Event();
            eventItem1.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem1.Title = "party";
            eventItem1.Location = "nowhere";
            eventManager.AddEvent(eventItem1);

            Event eventItem2 = new Event();
            eventItem2.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem2.Title = "no party";
            eventManager.AddEvent(eventItem2);

            Event eventItem3 = new Event();
            eventItem3.Date = DateTime.ParseExact(
                "2011-02-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem3.Title = "C#";
            eventItem3.Location = "Telerik";
            eventManager.AddEvent(eventItem3);

            var eventsList = eventManager.ListEvents(
                DateTime.ParseExact(
                    "2001-01-01T10:00:00",
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture),
                10);

            int eventsCount = eventsList.Count();

            Assert.AreEqual(3, eventsCount);
        }

        [TestMethod]
        public void TestListEvents_List2Of3()
        {
            FastEventsManager eventManager = new FastEventsManager();
            Event eventItem1 = new Event();
            eventItem1.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem1.Title = "party";
            eventItem1.Location = "nowhere";
            eventManager.AddEvent(eventItem1);

            Event eventItem2 = new Event();
            eventItem2.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem2.Title = "no party";
            eventManager.AddEvent(eventItem2);

            Event eventItem3 = new Event();
            eventItem3.Date = DateTime.ParseExact(
                "2011-02-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem3.Title = "C#";
            eventItem3.Location = "Telerik";
            eventManager.AddEvent(eventItem3);

            var eventsList = eventManager.ListEvents(
                DateTime.ParseExact(
                    "2001-01-01T10:00:00",
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture),
                2);

            int eventsCount = eventsList.Count();

            Assert.AreEqual(2, eventsCount);
        }

        [TestMethod]
        public void TestListEvents_OneEventBeforeTheSearchedOne()
        {
            FastEventsManager eventManager = new FastEventsManager();
            Event eventItem1 = new Event();
            eventItem1.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem1.Title = "party";
            eventItem1.Location = "nowhere";
            eventManager.AddEvent(eventItem1);

            Event eventItem2 = new Event();
            eventItem2.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem2.Title = "no party";
            eventManager.AddEvent(eventItem2);

            Event eventItem3 = new Event();
            eventItem3.Date = DateTime.ParseExact(
                "2000-02-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem3.Title = "C#";
            eventItem3.Location = "Telerik";
            eventManager.AddEvent(eventItem3);

            var eventsList = eventManager.ListEvents(
                DateTime.ParseExact(
                    "2001-01-01T10:00:00",
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture),
                10);

            int eventsCount = eventsList.Count();

            Assert.AreEqual(2, eventsCount);
        }

        [TestMethod]
        public void TesDeleteEvents_NoEventsAtAll()
        {
            FastEventsManager eventManager = new FastEventsManager();
            int deletedEvents = eventManager.DeleteEventsByTitle("title");

            Assert.AreEqual(0, deletedEvents);
        }

        [TestMethod]
        public void TestDeleteEvents_Delete1()
        {
            FastEventsManager eventManager = new FastEventsManager();
            Event eventItem = new Event();
            eventItem.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem.Title = "party";
            eventItem.Location = "nowhere";
            eventManager.AddEvent(eventItem);

            int deletedEvents = eventManager.DeleteEventsByTitle("party");

            Assert.AreEqual(1, deletedEvents);
        }

        [TestMethod]
        public void TestDeleteEvents_Delete1CheckCaseSensitivity()
        {
            FastEventsManager eventManager = new FastEventsManager();
            Event eventItem = new Event();
            eventItem.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem.Title = "pArTy";
            eventItem.Location = "nowhere";
            eventManager.AddEvent(eventItem);

            int deletedEvents = eventManager.DeleteEventsByTitle("party");

            Assert.AreEqual(1, deletedEvents);
        }

        [TestMethod]
        public void TestDeleteEvents_DeleteAll()
        {
            FastEventsManager eventManager = new FastEventsManager();
            Event eventItem1 = new Event();
            eventItem1.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem1.Title = "party";
            eventItem1.Location = "nowhere";
            eventManager.AddEvent(eventItem1);

            Event eventItem2 = new Event();
            eventItem2.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem2.Title = "party";
            eventManager.AddEvent(eventItem2);

            Event eventItem3 = new Event();
            eventItem3.Date = DateTime.ParseExact(
                "2011-02-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem3.Title = "party";
            eventItem3.Location = "Telerik";
            eventManager.AddEvent(eventItem3);

            int deletedEvents = eventManager.DeleteEventsByTitle("party");

            Assert.AreEqual(3, deletedEvents);
        }

        [TestMethod]
        public void TestDeleteEvents_Delete2Of3()
        {
            FastEventsManager eventManager = new FastEventsManager();
            Event eventItem1 = new Event();
            eventItem1.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem1.Title = "party";
            eventItem1.Location = "nowhere";
            eventManager.AddEvent(eventItem1);

            Event eventItem2 = new Event();
            eventItem2.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem2.Title = "no party";
            eventManager.AddEvent(eventItem2);

            Event eventItem3 = new Event();
            eventItem3.Date = DateTime.ParseExact(
                "2011-02-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem3.Title = "party";
            eventItem3.Location = "Telerik";
            eventManager.AddEvent(eventItem3);

            int deletedEvents = eventManager.DeleteEventsByTitle("party");

            Assert.AreEqual(2, deletedEvents);
        }

        [TestMethod]
        public void TestDeleteEvents_DeleteDuplicatedEvents()
        {
            FastEventsManager eventManager = new FastEventsManager();
            Event eventItem1 = new Event();
            eventItem1.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem1.Title = "party";
            eventItem1.Location = "nowhere";
            eventManager.AddEvent(eventItem1);

            Event eventItem2 = new Event();
            eventItem2.Date = DateTime.ParseExact(
                "2001-01-01T10:00:00",
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            eventItem2.Title = "party";
            eventItem2.Location = "nowhere";
            eventManager.AddEvent(eventItem2);

            int deletedEvents = eventManager.DeleteEventsByTitle("party");

            Assert.AreEqual(2, deletedEvents);
        }
    }
}