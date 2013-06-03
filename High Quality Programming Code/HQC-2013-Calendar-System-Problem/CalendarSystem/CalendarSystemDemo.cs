namespace CalendarSystem
{
    using System;
    using System.Text;

    public class CalendarSystemDemo
    {
        internal static void Main()
        {
            // FastEventsManager is faster than EventManager - bottleneck
            IEventsManager eventsManager = new FastEventsManager();
            CommandProcessor commandProcessor = new CommandProcessor(eventsManager);

            // With StringBuider it's easier to view the output and it's around 10s faster than
            // printing every time the command's output - bottleneck
            StringBuilder output = new StringBuilder();
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End" || inputLine == null)
                {
                    break;
                }

                try
                {
                    Command commandToProcess = Command.Parse(inputLine);
                    output.AppendLine(commandProcessor.ProcessCommand(commandToProcess));
                }
                catch (ArgumentException argException)
                {
                    Console.WriteLine(argException.Message);
                }
            }

            Console.Write(output.ToString());
        }
    }
}
