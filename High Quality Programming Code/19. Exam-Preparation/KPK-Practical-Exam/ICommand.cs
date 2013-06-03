namespace KPK_Practical_Exam
{
    public interface ICommand
    {
        CommandType Type { get; set; }

        string OriginalForm { get; set; }

        string Name { get; set; }

        string[] Parameters { get; set; }

        // I think that command is not a parser to have such methods

        // CommandType ParseCommandType(string commandName);

        // string ParseName();

        // string[] ParseParameters();
    }
}
