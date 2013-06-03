namespace CalendarSystem
{
    using System;

    public struct Command
    {
        public Command(string name, string[] parameters)
            : this()
        {
            this.Name = name;
            this.Parameters = parameters;
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }

        public static Command Parse(string inputCommand)
        {
            int index = inputCommand.IndexOf(' ');
            if (index == -1)
            {
                throw new ArgumentException("Invalid command: " + inputCommand);
            }

            string arguments = inputCommand.Substring(index + 1);
            string[] commandArguments = arguments.Split('|');

            for (int i = 0; i < commandArguments.Length; i++)
            {
                commandArguments[i] = commandArguments[i].Trim();
            }

            string name = inputCommand.Substring(0, index);

            Command command = new Command(name, commandArguments);

            return command;
        }
    }
}
