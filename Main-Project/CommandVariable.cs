namespace ASE_Assignment
{
    public class CommandVariable : Command
    {
        public string VariableName { get; set; }
        public int VariableValue { get; set; }

        public CommandVariable(Action actionWord, string variableName, int variableValue)
        {
            ActionWord = actionWord;
            VariableName = variableName;
            VariableValue = variableValue;
        }
    }
}
