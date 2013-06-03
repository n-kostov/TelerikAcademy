namespace KPK_Practical_Exam
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            List<ICommand> inputCommands = ReadInput();
            foreach (ICommand command in inputCommands)
            {
                commandExecutor.ExecuteCommand(catalog, command, output);
            }

            // Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(output); // printing the output
        }

        private static List<ICommand> ReadInput()
        {
            List<ICommand> inputCommands = new List<ICommand>();
            bool enteredEndCommand = false;

            do
            {
                string line = Console.ReadLine();
                enteredEndCommand = line.Trim() == "End";
                if (!enteredEndCommand)
                {
                    inputCommands.Add(new Command(line));
                }
                else
                {
                    break;
                }
            }
            while (true);

            return inputCommands;
        }
    }
}
