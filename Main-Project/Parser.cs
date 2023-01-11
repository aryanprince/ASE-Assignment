using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ASE_Assignment
{
    public class Parser
    {
        public CommandVariable ParseInput_Variable(string input, Dictionary<string, int> dict)
        {
            // input = "var z = x + y" this should assign the value of x + y from the dictionary to z using DataTable.Compute method

            // split the input into 3 parts
            string[] parts = input.Split('=');
            string expression = parts[1].Trim();
            string variableName = parts[0].Substring(3).Trim();

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

            //Create a new CommandVariable object
            CommandVariable commandVariable = new CommandVariable(Action.var, variableName, result);

            return commandVariable;
        }

        public CommandShapeNum ParseInput_ShapeWithVariables(string input, Dictionary<string, int> dict)
        {
            // input = "rectangle x y" or "circle x"
            // replace values of x and y with the values in the dictionary

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

            // Create a new CommandShape object
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
        public bool ParseInput_IfStatements(string input, Dictionary<string, int> dict)
        {
            // input = "if x > 100"
            // replace values of x with the values in the dictionary

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

            // Check if the input is valid
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

        //public List<ICommand> ParseSingleLine(string line)
        //{
        //    string[] words = line.Split(' ');
        //    string commandType = words[0];

        //    switch (commandType)
        //    {
        //        case "var":
        //            // parse variable assignment and return a CommandVariable object
        //            string variableName = words[1];
        //            string variableValue = words[3];
        //            return new List<ICommand> { new CommandVariable(Action.var, variableName, int.Parse(variableValue)) };
        //        default:
        //            // parse shape command and return a CommandShape object
        //            Action actionWord = ParseAction_Command(commandType);
        //            int[] actionValues = ParseAction_CommandParameters(words.Skip(1).ToArray());
        //            return new List<ICommand> { new CommandShape(actionWord, actionValues) };
        //    }
        //}
        //public List<ICommand> ParseMultiline(string inputText)
        //{
        //    string[] lines = inputText.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        //    List<ICommand> commands = new List<ICommand>();
        //    foreach (string line in lines)
        //    {
        //        commands.AddRange(ParseSingleLine(line));
        //    }
        //    return commands;
        //}

        /// <summary>
        /// Parses a single string, splitting them by words into a Command object.
        /// </summary>
        /// <param name="inputFull">String input from the Text Box.</param>
        /// <returns>Command object containing an action and parameters.</returns>
        /// <exception cref="FormatException"></exception>
        public CommandShapeNum ParseInput_SingleLine(string inputFull)
        {
            inputFull = inputFull.Trim().ToLower(); // Trim the input and convert it to lowercase

            // Split the input string into an array of strings, separated by spaces
            string[] inputSplitBySpaces = inputFull.ToLower().Split(' ');

            /* +---------------+
                * | COMMAND NAME  |
                * +---------------+ 
                */
            // Parses the command string
            string stringCommand = inputSplitBySpaces[0];
            Action actionWord = ParseAction_Command(stringCommand);

            if (actionWord == Action.none)
                throw new Exception("ERROR: Invalid command!");

            // If the command action is valid, but no parameters are passed - it throws this exception
            if (inputSplitBySpaces.Length == 1 && actionWord != Action.run && actionWord != Action.clear && actionWord != Action.reset)
            {
                throw new Exception("ERROR: Please use a parameter with this command.");
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
            //return new List<ICommand> { new CommandShape(actionWord, actionParams) };
        }


        /// <summary>
        /// Parses a large multi-line string into a list of Commands, each parsed by ParseInput_SingleLine() method.
        /// </summary>
        /// <param name="inputFull">String input from the multi-line Text Box.</param>
        /// <returns>A list of Command objects, each containing an action and parameters.</returns>
        public List<CommandShapeNum> ParseInput_MultiLine(string inputFull)
        {
            // Splits the multi-line string by a new line and stores this in a new list
            List<CommandShapeNum> commandsList = new List<CommandShapeNum>();
            string[] inputSplitByLines = inputFull.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // Windows splits newlines by '\r\n' so here we split by 2 chars and remove any empty string split entries

            // Loops around the list of commands, calling the single line parser on every element in the commandsList list
            inputSplitByLines.ToList().ForEach(input => commandsList.Add(ParseInput_SingleLine(input))); // ForEach command from System.LINQ used here instead of a typical for-each loop
            return commandsList;
        }

        /// <summary>
        /// Parses the first word from ParseInput_SingleLine() to determine an action.
        /// </summary>
        /// <param name="input">String value for an Action.</param>
        /// <returns>An Action enum representing a command for the Command class, or Action.none if nothing is found.</returns>
        public Action ParseAction_Command(string input)
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
        /// Parses the string parameters from ParseInput_SingleLine() to convert them to usable int values.
        /// </summary>
        /// <param name="inputStringArray">String parameters for an Action.</param>
        /// <returns>An integer array of parameters for the Command class.</returns>
        private int[] ParseAction_CommandParameters(string[] inputStringArray)
        {
            int[] inputIntArray;

            try
            {
                inputIntArray = Array.ConvertAll(inputStringArray, int.Parse);
            }
            catch (FormatException)
            {
                throw new ArgumentException("ERROR: Invalid parameters, please use int!", inputStringArray.ToString());
            }

            // Checks if parameters are negative and throws an error if it is
            for (int i = 0; i < inputIntArray.Length; i++)
            {
                if (inputIntArray[i] < 0)
                    throw new ArgumentOutOfRangeException(inputIntArray[i].ToString(), "ERROR: Negative parameters are not allowed!");
            }

            // This may be redundant now since the try-catch block above should catch any invalid parameters
            //// Checks if the string parameter contains only numbers before parsing them
            //foreach (var s in inputStringArray)
            //{
            //    if (!s.All(char.IsDigit))
            //        throw new FormatException("ERROR: Invalid parameters, please use int!");
            //}

            // Checks if any of the parameters are greater than the window size (900x500)
            switch (inputIntArray.Length)
            {
                case 2: // When there are 2 parameters, check if they are greater than 900 and 500 respectively
                    {
                        if (inputIntArray[0] > 900)
                            throw new ArgumentOutOfRangeException(inputIntArray[0].ToString(), "ERROR: Invalid parameters\nX-value for parameter must be less than 900!");
                        if (inputIntArray[1] > 500)
                            throw new ArgumentOutOfRangeException(inputIntArray[1].ToString(), "ERROR: Invalid parameters\nY-value for parameter must be less than 500!");
                        break;
                    }
                default: // When there is only 1 parameter, check if it's greater than 900
                    if (inputIntArray[0] > 900)
                        throw new ArgumentOutOfRangeException(inputIntArray[0].ToString(), "ERROR: Invalid parameters\nX-value for parameter must be less than 900!");
                    break;
            }

            return inputIntArray;
        }
    }
}