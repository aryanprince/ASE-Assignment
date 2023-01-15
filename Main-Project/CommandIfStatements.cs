namespace ASE_Assignment
{
    /// <summary>
    /// A class that implements the <see cref="Command" /> parent class and is used to store the information parsed from an if statement command.
    /// </summary>
    /// <seealso cref="Command" />
    public class CommandIfStatements : Command
    {
        public bool IfState { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        /// <summary>
        /// Constructor used to create a new instance of the <see cref="CommandIfStatements"/> class.
        /// </summary>
        /// <param name="actionWord">The action word.</param>
        /// <param name="ifState">if set to <c>true</c> [if state].</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="endIndex">The end index.</param>
        public CommandIfStatements(Action actionWord, bool ifState, int startIndex, int endIndex)
        {
            ActionWord = actionWord;
            IfState = ifState;
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
