namespace ASE_Assignment
{
    public class Command
    {
        public Action ActionWord { get; set; }
        public int[] ActionValues { get; set; }

        public Command(Action actionWord, int[] actionValues)
        {
            ActionWord = actionWord;
            ActionValues = actionValues;
        }
    }
}
