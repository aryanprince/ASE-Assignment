namespace ASE_Assignment
{
    public class CommandIfStatements : Command
    {
        public bool IfState { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public CommandIfStatements(Action actionWord, bool ifState, int startIndex, int endIndex)
        {
            ActionWord = actionWord;
            IfState = ifState;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
