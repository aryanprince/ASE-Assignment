namespace ASE_Assignment
{
    public class CommandShapeNum : Command
    {
        public int[] ActionValues { get; set; }

        public CommandShapeNum(Action actionWord, int[] actionValues)
        {
            ActionWord = actionWord;
            ActionValues = actionValues;
        }
    }
}
