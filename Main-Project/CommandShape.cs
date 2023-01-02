namespace ASE_Assignment
{
    public class CommandShape
    {
        public Action ActionWord { get; set; }
        public int[] ActionValues { get; set; }

        public CommandShape(Action actionWord, int[] actionValues)
        {
            ActionWord = actionWord;
            ActionValues = actionValues;
        }
    }
}
