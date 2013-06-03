namespace KPK_Practical_Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder result)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    {
                        contentCatalog.Add(new Content(ContentType.Book, command.Parameters));
                        result.AppendLine("Book added");
                    }

                    break;

                case CommandType.AddMovie:
                    {
                        contentCatalog.Add(new Content(ContentType.Movie, command.Parameters));
                        result.AppendLine("Movie added");
                    }

                    break;

                case CommandType.AddSong:
                    {
                        contentCatalog.Add(new Content(ContentType.Song, command.Parameters));
                        result.AppendLine("Song added");
                    }

                    break;

                case CommandType.AddApplication:
                    {
                        contentCatalog.Add(new Content(ContentType.Application, command.Parameters));
                        result.AppendLine("Application added");
                    }

                    break;

                case CommandType.Update:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            throw new ArgumentException("Update can only be used with 2 parameters!");
                        }

                        result.AppendLine(string.Format("{0} items updated",
                            contentCatalog.UpdateContent(command.Parameters[0], command.Parameters[1])));
                    }

                    break;

                case CommandType.Find:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            throw new ArgumentException("Find can only be used with 2 parameters!");
                        }

                        int numberOfElementsToList = int.Parse(command.Parameters[1]);
                        IEnumerable<IContent> foundContent = contentCatalog.GetListContent(command.Parameters[0], numberOfElementsToList);
                        this.StringifyFoundContent(foundContent, result);
                    }

                    break;

                default:
                    {
                        throw new InvalidCastException("Unknown command!");
                    }
            }
        }

        private void StringifyFoundContent(IEnumerable<IContent> foundContent, StringBuilder result)
        {
            if (foundContent.Count() == 0)
            {
                result.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    result.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}
