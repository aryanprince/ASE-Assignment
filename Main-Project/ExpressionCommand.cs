using System.Collections.Generic;

namespace ASE_Assignment
{
    public class ExpressionCommand
    {
        Dictionary<string, int> expressionsDict = new Dictionary<string, int>();

        public ExpressionCommand(string variableName, int variableValue)
        {
            expressionsDict[variableName] = variableValue;
        }
    }
}
