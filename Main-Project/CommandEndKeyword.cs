namespace ASE_Assignment
{
    /// <summary>
    /// A class that implements the <see cref="Command" /> parent class and is used to store the end keyword of both if statements and while loops.
    /// </summary>
    /// <seealso cref="Command" />
    public class CommandEndKeyword : Command
    {
        /// <summary>
        /// Constructor used to create a new instance of the <see cref="CommandEndKeyword" /> class.
        /// </summary>
        /// <param name="actionWord">The action word.</param>
        public CommandEndKeyword(Action actionWord)
        {
            ActionWord = actionWord;
        }
    }
}
