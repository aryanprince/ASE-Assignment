namespace ASE_Assignment
{
    /// <summary>
    /// A class that implements the <see cref="Command" /> parent class and is used to store information parsed from a regular command to draw a shape using numerical parameters.
    /// </summary>
    /// <seealso cref="Command" />
    public class CommandShapeNum : Command
    {
        public int[] ActionValues { get; set; }

        /// <summary>
        /// Constructor used to create a new instance of the <see cref="CommandShapeNum"/> class.
        /// </summary>
        /// <param name="actionWord">The action word.</param>
        /// <param name="actionValues">The action values.</param>
        public CommandShapeNum(Action actionWord, int[] actionValues)
        {
            ActionWord = actionWord;
            ActionValues = actionValues;
        }
    }
}
