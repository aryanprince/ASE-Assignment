using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace ASE_Assignment
{
    public class Parser
    {
        private const string RegexDrawWithVariables = @"^([a-zA-Z]+)\s*([a-zA-Z]+)? ?([a-zA-Z]+)?$"; // "rectangle x y" or "circle x"
        private const string RegexDrawShapesWithNumbers = @"^([a-zA-Z]+)\s*(\d+)?\s*(\d+)?$"; // "rectangle 100 150" or "circle 50"
        private const string RegexVariables = @"^var.+"; // "var x = 5" or "var x = y + 85"
        private const string RegexIfStatements = @"if [a-zA-Z] (?:>|<|==) \d+"; // "if x > 5"
        private const string RegexWhileLoops = @"while.+"; // "while 10"
        private const string RegexEndStatements = @"end.+"; // "endif" or "endwhile"

        /// <summary>
        /// The main parser method, calls other parser methods based on various type of commands
        /// </summary>
        /// <param name="input"> The input string to parse </param>
        /// <param name="dict"> A dictionary containing variable names and their values </param>
        /// <returns> A list of Command objects representing the commands from the input </returns>
        public List<Command> Parse(string input, Dictionary<string, int> dict)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null");
            }

            // Split input into separate lines
            string[] inputSplitByLines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // List to hold the commands
            List<Command> commandsList = new List<Command>();

            // Iterate through each line of input
            foreach (string s in inputSplitByLines)
            {
                // Trim and convert the line to lowercase for easier matching
                string line = s.Trim().ToLower();

                // WHILE LOOPS (example: "while 10")
                if (Regex.IsMatch(line.Trim().ToLower(), RegexWhileLoops))
                {
                    Command command = ParseWhile(line);
                    commandsList.Add(command);
                }

                // END COMMANDS (example: "endif" or "endwhile")
                else if (Regex.IsMatch(line.Trim().ToLower(), RegexEndStatements))
                {
                    Command command = new CommandEndKeyword(Action.endif);
                    commandsList.Add(command);
                }

                // DRAW SHAPES WITH NUMBERS (example: "rectangle 100 150" or "circle 50")
                else if (Regex.IsMatch(line.Trim().ToLower(), RegexDrawShapesWithNumbers))
                {
                    Command command = ParseDrawShape_WithNumbers(line);
                    commandsList.Add(command);
                }

                // DRAW SHAPES WITH VARIABLES (example: "rectangle x y" or "circle x")
                else if (Regex.IsMatch(line.Trim().ToLower(), RegexDrawWithVariables))
                {
                    Command command = ParseDrawShape_WithVariables(line, dict);
                    commandsList.Add(command);
                }

                // VARIABLE ASSIGNMENT (example: "var x = 10" or "var x = y + 100")
                else if (Regex.IsMatch(line.Trim().ToLower(), RegexVariables))
                {
                    CommandVariable command = ParseVariable(line, dict);
                    // If the variable is already in the dictionary, replace it with the new value
                    if (dict.ContainsKey(command.VariableName))
                        dict[command.VariableName] = command.VariableValue;
                    else
                        dict.Add(command.VariableName, command.VariableValue);
                    commandsList.Add(command);
                }

                // IF STATEMENTS (example: "if x > 5")
                else if (Regex.IsMatch(line.Trim().ToLower(), RegexIfStatements))
                {
                    // Find the line number where the if statement ends at using "endif" as the end of the if statement
                    int startIndex = Array.IndexOf(inputSplitByLines, line);
                    int endIndex = Array.IndexOf(inputSplitByLines, "endif");
                    bool result = ParseIfStatements(line, dict);

                    Command command = new CommandIfStatements(Action.ifstatement, result, startIndex, endIndex);
                    commandsList.Add(command);
                }

                // DEFAULT CASE
                else
                {
                    throw new ArgumentException("ERROR: Invalid input!");
                }
            }

            // Return the list of commands
            return commandsList;
        }

        /// <summary>
        /// Parses a single string, splitting them by words into a Command object.
        /// </summary>
        /// <param name="inputFull">String input from the Text Box.</param>
        /// <returns>Command object containing an action and parameters.</returns>
        /// <exception cref="FormatException"> Throws an exception when incorrect parameters are being passed </exception>
        /// <example> "rectangle 100 50", "circle x", "pen 1", "clear" </example>
        public CommandShapeNum ParseDrawShape_WithNumbers(string inputFull)
        {
            inputFull = inputFull.Trim().ToLower(); // Trim the input and convert it to lowercase

            // Split the input string into an array of strings, separated by spaces
            string[] inputSplitBySpaces = inputFull.ToLower().Split(' ');

            if (inputSplitBySpaces.Length >= 4)
            {
                throw new ArgumentException("ERROR: Too many parameters passed!");
            }

            /* +---------------+
                * | COMMAND NAME  |
                * +---------------+ 
                */
            // Parses the command string
            string stringCommand = inputSplitBySpaces[0];
            Action actionWord = ParseAction_CommandName(stringCommand);

            if (actionWord == Action.none)
                throw new ArgumentException("ERROR: Invalid command!");

            // If the command action is valid, but no parameters are passed - it throws this exception
            if (inputSplitBySpaces.Length == 1 && actionWord != Action.run && actionWord != Action.clear && actionWord != Action.reset)
            {
                throw new ArgumentException("ERROR: Please use a parameter with this command.");
            }
            if (actionWord == Action.run || actionWord == Action.reset || actionWord == Action.clear)
            {
                return new CommandShapeNum(actionWord, null);
            }

            /* +---------------------+
                * | COMMAND PARAMETERS |
                * +--------------------+ 
                */
            // Parses the parameters of the command
            List<string> stringParamsList = new List<string>();
            for (int i = 1; i < inputSplitBySpaces.Length; i++)
            {
                stringParamsList.Add(inputSplitBySpaces[i]);
            }
            string[] stringParams = stringParamsList.ToArray();


            int[] actionParams = ParseAction_CommandParameters(stringParams);

            // Uses the parsed command string and command parameters to create and return a Command object
            return new CommandShapeNum(actionWord, actionParams);
        }

        /// <summary>
        /// Parses a variable declaration string by computing variable expressions using a helper method
        /// </summary>
        /// <param name="input"> The input string to parse </param>
        /// <param name="dict"> The dictionary of variables and their values </param>
        /// <returns> A CommandVariable object with information from the variable declaration </returns>
        /// <example> "var x = 150" or "var z = x + y" </example>
        private CommandVariable ParseVariable(string input, Dictionary<string, int> dict)
        {
            // This should assign the value of x + y from the dictionary to z using DataTable.Compute method

            // split the input into 3 parts
            string[] parts = input.Split('=');
            string expression = parts[1].Trim();
            string variableName = parts[0].Substring(3).Trim();

            int result = CalculateExpression(dict, expression);

            //Create a new CommandVariable object
            CommandVariable commandVariable = new CommandVariable(Action.var, variableName, result);

            return commandVariable;
        }

        /// <summary>
        /// This method will calculate the expression using DataTable's Compute method
        /// </summary>
        /// <param name="dict"> Dictionary stores variables and their values </param>
        /// <param name="expression"> Expression to be calculated </param>
        /// <returns> Result of the expression as an integer </returns>
        /// <example> "100 + 30 + 90" will return 220 as an integer </example>
        private static int CalculateExpression(Dictionary<string, int> dict, string expression)
        {
            //Check dictionary to replace values of x and y with their values to get the result
            foreach (KeyValuePair<string, int> entry in dict)
            {
                if (expression.Contains(entry.Key))
                {
                    expression = expression.Replace(entry.Key, entry.Value.ToString());
                }
            }

            //Calculate the result of the expression
            int result = Convert.ToInt32(new DataTable().Compute(expression, null));
            return result;
        }

        /// <summary>
        /// Parse an input string for drawing shape commands that use variables, instead of numbers
        /// </summary>
        /// <param name="input"> The input string to parse </param>
        /// <param name="dict"> The dictionary of variables and their values </param>
        /// <returns> A Command object with the parsed information </returns>
        /// <exception cref="ArgumentException"> Thrown when the input string is not a valid command </exception>
        /// <example> "rectangle x y" or "circle x" </example>
        private CommandShapeNum ParseDrawShape_WithVariables(string input, Dictionary<string, int> dict)
        {
            // Split the input into an array of strings
            string[] inputArray = input.Split(' ');

            // Check if the input is valid
            if (inputArray.Length < 2)
            {
                throw new ArgumentException("Invalid input");
            }

            // Check if the input is valid
            if (!Enum.TryParse(inputArray[0], true, out Action actionWord))
            {
                throw new ArgumentException("Invalid input");
            }

            // Check if the input is valid
            if (!dict.ContainsKey(inputArray[1]))
            {
                throw new ArgumentException("Invalid input");
            }

            // Create a new CommandShape object and replaces values of x and y with the values in the dictionary
            CommandShapeNum commandShape = new CommandShapeNum(actionWord, new int[] { dict[inputArray[1]] });

            // Check if the input is valid
            if (inputArray.Length == 3)
            {
                // Check if the input is valid
                if (!dict.ContainsKey(inputArray[2]))
                {
                    throw new ArgumentException("Invalid input");
                }

                // Add the second value to the CommandShape object
                commandShape.ActionValues = commandShape.ActionValues.Concat(new int[] { dict[inputArray[2]] }).ToArray();
            }

            return commandShape;
        }

        /// <summary>
        /// Parses the input as a string to return an instance of the CommandIfStatement class
        /// </summary>
        /// <param name="input"> Input for an if statement in a string format </param>
        /// <param name="dict"> A dictionary containing variable names and their values </param>
        /// <returns> A CommandIfStatement object </returns>
        /// <exception cref="ArgumentException"> Throws exceptions when input passed in an incorrect </exception>
        /// <example> "if x &gt; 100" </example>
        private bool ParseIfStatements(string input, Dictionary<string, int> dict)
        {
            // Split the input into an array of strings
            string[] inputArray = input.Split(' ');

            // Check if the input is valid
            if (inputArray.Length != 4)
            {
                throw new ArgumentException("Invalid input");
            }

            // Check if the input is valid
            if (inputArray[0] != "if")
            {
                throw new ArgumentException("Invalid input");
            }

            // Check if the input is valid
            if (!dict.ContainsKey(inputArray[1]))
            {
                throw new ArgumentException("Invalid input");
            }

            // Check if the input is valid
            if (!int.TryParse(inputArray[3], out int variableValue))
            {
                throw new ArgumentException("Invalid input");
            }

            // Check if the input is valid and replace values of variables with the values from the dictionary
            if (inputArray[2] == ">")
            {
                if (dict[inputArray[1]] > variableValue)
                {
                    return true;
                }
            }
            else if (inputArray[2] == "<")
            {
                if (dict[inputArray[1]] < variableValue)
                {
                    return true;
                }
            }
            else if (inputArray[2] == "==")
            {
                if (dict[inputArray[1]] == variableValue)
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }

            return false;
        }

        /// <summary>
        /// Parses the first word from ParseDrawShape_WithNumbers() to determine an action.
        /// </summary>
        /// <param name="input">String value for an Action.</param>
        /// <returns>An Action enum representing a command for the Command class, or Action.none if nothing is found.</returns>
        public Action ParseAction_CommandName(string input)
        {
            input = input.Split()[0].Trim().ToLower(); // Cleans the input string by removing any extra words (if any) in the input string

            // Returns an appropriate Action enum for a given string
            switch (input)
            {
                case "rectangle":
                    return Action.rectangle;
                case "square":
                    return Action.square;
                case "circle":
                    return Action.circle;
                case "triangle":
                    return Action.triangle;
                case "drawto":
                    return Action.drawto;
                case "move":
                    return Action.move;
                case "reset":
                    return Action.reset;
                case "clear":
                    return Action.clear;
                case "fill":
                    return Action.fill;
                case "pen":
                    return Action.pen;
                case "run":
                    return Action.run;
                default:
                    return Action.none;
            }
        }

        /// <summary>
        /// Parses the string parameters from ParseDrawShape_WithNumbers() to convert them to usable int values.
        /// </summary>
        /// <param name="inputStringArray">String parameters for an Action.</param>
        /// <exception cref="ArgumentException"> Throws an exceptions when passing invalid or negative parameter values </exception>
        /// <returns>An integer array of parameters for the Command class.</returns>
        private int[] ParseAction_CommandParameters(string[] inputStringArray)
        {
            int[] inputIntArray;

            try
            {
                // Converts each element of the string array to an int
                inputIntArray = Array.ConvertAll(inputStringArray, int.Parse);
            }
            catch (FormatException)
            {
                // Throws an exception if any of the elements in the inputStringArray cannot be parsed to int
                throw new ArgumentException("ERROR: Invalid parameters, please use int!", inputStringArray.ToString());
            }

            // Checks if parameters are negative and throws an error if it is
            for (int i = 0; i < inputIntArray.Length; i++)
            {
                if (inputIntArray[i] < 0)
                    throw new ArgumentException("ERROR: Negative parameters are not allowed!");
            }

            // Checks if any of the parameters are greater than the window size (900x500)
            switch (inputIntArray.Length)
            {
                case 2: // When there are 2 parameters, check if they are greater than 900 and 500 respectively
                    {
                        if (inputIntArray[0] > 900)
                            throw new ArgumentException("ERROR: Invalid parameters\nX-value for parameter must be less than 900!");
                        if (inputIntArray[1] > 500)
                            throw new ArgumentException("ERROR: Invalid parameters\nY-value for parameter must be less than 500!");
                        break;
                    }
                default: // When there is only 1 parameter, check if it's greater than 900
                    if (inputIntArray[0] > 900)
                        throw new ArgumentException("ERROR: Invalid parameters\nX-value for parameter must be less than 900!");
                    break;
            }

            return inputIntArray;
        }

        /// <summary>
        /// Parses a "while" command from the input string and creates a CommandWhile object with the specified loop count.
        /// </summary>
        /// <param name="input">The input string to parse</param>
        /// <returns>A CommandWhile object representing the "while" command</returns>
        /// <example> "while 10" loops 10 times </example>
        private Command ParseWhile(string input)
        {
            // Split the input string by spaces to separate the command keyword and the loop count
            string[] inputSplitBySpaces = input.Split(' ');

            // Create a CommandWhile object with the specified loop count
            Command command = new CommandWhile(Action.whileloop, int.Parse(inputSplitBySpaces[1]));
            return command;
        }
    }
}