namespace KPK_Practical_Exam
{
    using System;
    using System.Linq;
    using System.Text;

    public class Command : ICommand
    {
        private readonly char[] paramsSeparators = { ';' };
        private readonly char commandEnd = ':';
        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.Name);
            result.Append(' ');

            foreach (string param in this.Parameters)
            {
                result.Append(param);
                result.Append(' ');
            }

            return result.ToString();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        private CommandType ParseCommandType(string commandName)
        {
            CommandType type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException();
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    {
                        type = CommandType.AddBook;
                    }

                    break;

                case "Add movie":
                    {
                        type = CommandType.AddMovie;
                    }

                    break;

                case "Add song":
                    {
                        type = CommandType.AddSong;
                    }

                    break;

                case "Add application":
                    {
                        type = CommandType.AddApplication;
                    }

                    break;

                case "Update":
                    {
                        type = CommandType.Update;
                    }

                    break;

                case "Find":
                    {
                        type = CommandType.Find;
                    }

                    break;

                default:
                    {
                        if (commandName.ToLower().Contains("book") || commandName.ToLower().Contains("movie") ||
                            commandName.ToLower().Contains("song") || commandName.ToLower().Contains("application"))
                        {
                            throw new InsufficientExecutionStackException();
                        }

                        if (commandName.ToLower().Contains("find") || commandName.ToLower().Contains("update"))
                        {
                            throw new InvalidProgramException();
                        }

                        throw new MissingFieldException("Invalid command name!");
                    }
            }

            return type;
        }

        private string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex);
            return name;
        }

        private string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 2);
            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 2, paramsLength);
            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        private int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(this.commandEnd);
            return endIndex;
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }
    }
}
