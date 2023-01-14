namespace ASE_Assignment
{
    internal class CommandWhile : Command
    {
        public int LoopCount { get; set; }

        public CommandWhile(Action actionWord, int loopCount)
        {
            ActionWord = actionWord;
            LoopCount = loopCount;
        }
    }
}