using System;
using System.Collections.Generic;
using System.Linq;

namespace ASE_Assignment
{
    public class Parser
    {
        /// <summary>
        /// Parses a single string, splitting them by words into a Command object.
        /// </summary>
        /// <param name="inputFull">String input from the Text Box.</param>
        /// <returns>Command object containing an action and parameters.</returns>
        /// <exception cref="FormatException"></exception>
        public Command ParseInput_SingleLine(string inputFull)
        {
            inputFull = inputFull.Trim().ToLower(); // Trim the input and convert it to lowercase

            // Split the input string into an array of strings, separated by spaces
            var inputSplitBySpaces = inputFull.ToLower().Split(' ');

            // Invalid when no words are passed
            if (inputFull.Equals(""))
                throw new Exception("ERROR: No commands were passed.");

            // Invalid when more than 3 words are passed to the parser
            if (inputSplitBySpaces.Length > 3)
                throw new Exception("ERROR: Too many parameters or words.");

            // Parses the command string
            var stringCommand = inputSplitBySpaces[0];
            var actionWord = ParseAction_Command(stringCommand);

            if (actionWord == Action.none)
                throw new Exception("ERROR: Invalid command!");
            // If the command action is valid, but no parameters are passed - it throws this exception
            if (inputSplitBySpaces.Length == 1 && actionWord != Action.run && actionWord != Action.clear && actionWord != Action.reset)
            {
                throw new Exception("ERROR: Please use a parameter with this command.");
            }
            if (actionWord == Action.run || actionWord == Action.reset || actionWord == Action.clear)
            {
                return new Command(actionWord, null);
            }

            // Parses the parameters of the command
            var stringParamsList = new List<string>();
            for (int i = 1; i < inputSplitBySpaces.Length; i++)
            {
                stringParamsList.Add(inputSplitBySpaces[i]);
            }
            var stringParams = stringParamsList.ToArray();

            // Checks if the string parameter contains only numbers before parsing them
            foreach (var s in stringParams)
            {
                if (!s.All(char.IsDigit))
                    throw new Exception("ERROR: Invalid parameters, please use int!");
            }

            var actionParams = ParseAction_CommandParameters(stringParams);

            // Uses the parsed command string and command parameters to create and return a Command object
            return new Command(actionWord, actionParams);
        }

        /// <summary>
        /// Parses a large multi-line string into a list of Commands, each parsed by ParseInput_SingleLine() method.
        /// </summary>
        /// <param name="inputFull">String input from the multi-line Text Box.</param>
        /// <returns>A list of Command objects, each containing an action and parameters.</returns>
        public List<Command> ParseInput_MultiLine(string inputFull)
        {
            // Splits the multi-line string by a new line and stores this in a new list
            var commandsList = new List<Command>();
            var inputSplitByLines = inputFull.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // Windows splits newlines by '\r\n' so here we split by 2 chars and remove any empty string split entries

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
        public int[] ParseAction_CommandParameters(string[] inputStringArray)
        {
            var inputIntArray = Array.ConvertAll(inputStringArray, int.Parse);

            // Checks if any of the parameters are greater than the window size (900x500)
            switch (inputIntArray.Length)
            {
                case 2: // When there are 2 parameters, check if they are greater than 900 and 500 respectively
                    {
                        if (inputIntArray[0] > 900)
                            throw new Exception("ERROR: Invalid parameters\nX-value for parameter must be less than 900!");
                        if (inputIntArray[1] > 500)
                            throw new Exception("ERROR: Invalid parameters\nY-value for parameter must be less than 500!");
                        break;
                    }
                default: // When there is only 1 parameter, check if it's greater than 900
                    if (inputIntArray[0] > 900)
                        throw new Exception("ERROR: Invalid parameters\nX-value for parameter must be less than 900!");
                    break;
            }

            return inputIntArray;
        }
    }
}
