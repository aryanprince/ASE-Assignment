namespace ASE_Assignment
{
    /// <summary>
    /// A class that implements the <see cref="Command" /> parent class and is used to store values from a variable declaration command.
    /// </summary>
    /// <seealso cref="Command" />
    public class CommandVariable : Command
    {
        public string VariableName { get; set; }
        public int VariableValue { get; set; }

        /// <summary>
        /// Constructor used to create a new instance of the <see cref="CommandVariable"/> class.
        /// </summary>
        /// <param name="actionWord">The action word.</param>
        /// <param name="variableName">Name of the variable.</param>
        /// <param name="variableValue">The variable value.</param>
        public CommandVariable(Action actionWord, string variableName, int variableValue)
        {
            ActionWord = actionWord;
            VariableName = variableName;
            VariableValue = variableValue;
        }
    }
}
