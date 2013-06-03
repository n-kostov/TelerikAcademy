namespace CalendarSystem
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CommandProcessor
    {
        private readonly IEventsManager eventsManager;

        public CommandProcessor(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public IEventsManager EventsManager
        {
            get
            {
                return this.eventsManager;
            }
        }

        public string ProcessCommand(Command command)
        {
            if (command.Name == "AddEvent")
            {
                return this.ExecuteAddEvent(command);
            }
            else if ((command.Name == "DeleteEvents") && (command.Parameters.Length == 1))
            {
                return this.ExecuteDeleteEvents(command);
            }
            else if ((command.Name == "ListEvents") && (command.Parameters.Length == 2))
            {
                return this.ExecuteListEvents(command);
            }
            else
            {
                throw new ArgumentException("WTF " + command.Name + " is?", "command.CommandName");
            }
        }

        private string ExecuteAddEvent(Command command)
        {
            var date = DateTime.ParseExact(
                command.Parameters[0],
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            var eventItem = new Event
            {
                Date = date,
                Title = command.Parameters[1],
            };

            if (command.Parameters.Length == 2)
            {
                eventItem.Location = null;
            }
            else if (command.Parameters.Length == 3)
            {
                eventItem.Location = command.Parameters[2];
            }
            else
            {
                throw new ArgumentException("WTF " + command.Name + " is?", "command.CommandName");
            }

            this.eventsManager.AddEvent(eventItem);

            return "Event added";
        }

        private string ExecuteDeleteEvents(Command command)
        {
            int deletedEvents = this.eventsManager.DeleteEventsByTitle(command.Parameters[0]);

            if (deletedEvents == 0)
            {
                return "No events found";
            }

            return deletedEvents + " events deleted";
        }

        private string ExecuteListEvents(Command command)
        {
            var date = DateTime.ParseExact(
                command.Parameters[0],
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture);

            var count = int.Parse(command.Parameters[1]);
            var eventsList = this.eventsManager.ListEvents(date, count).ToList();
            StringBuilder output = new StringBuilder();

            if (!eventsList.Any())
            {
                return "No events found";
            }

            foreach (var eventItem in eventsList)
            {
                output.AppendLine(eventItem.ToString());
            }

            return output.ToString().Trim();
        }
    }
}
