namespace ASE_Assignment
{
    public class CommandShapeVar : Command
    {
        public string[] ActionValues { get; set; }

        public CommandShapeVar(Action actionWord, string[] actionValues)
        {
            ActionWord = actionWord;
            ActionValues = actionValues;
        }
    }
}
