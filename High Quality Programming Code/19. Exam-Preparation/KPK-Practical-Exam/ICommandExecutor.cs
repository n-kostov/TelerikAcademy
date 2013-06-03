namespace KPK_Practical_Exam
{
    using System.Text;

    public interface ICommandExecutor
    {
        void ExecuteCommand(ICatalog contentCatalog, ICommand command, StringBuilder output);
    }
}
