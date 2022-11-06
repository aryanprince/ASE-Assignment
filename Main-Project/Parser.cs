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
        public Command ParseInput_SingleLine(string inputFull) // ParseInput_SingleLine is a method that takes a string as input and returns a Command object
        {
            string[] inputSplitBySpaces = inputFull.ToLower().Split(' '); // Split the input string into an array of strings, separated by spaces

            if (inputSplitBySpaces.Length > 3) // Invalid when more than 3 words
                throw new FormatException();

            string stringCommand = inputSplitBySpaces[0];

            List<string> stringParamsList = new List<string>();
            for (int i = 1; i < inputSplitBySpaces.Length; i++)
            {
                stringParamsList.Add(inputSplitBySpaces[i]);
            }
            string[] stringParams = stringParamsList.ToArray();


            Action actionWord = ParseAction_Command(stringCommand); // Set the ActionWord property of the Command object to the Action enum value returned by ParseAction
            int[] actionParams = ParseAction_CommandParameters(stringParams); // Set the ActionValues property of the Command object to the array of integers returned by ParseValues

            return new Command(actionWord, actionParams); // Creates and returns a Command object
        }

        /// <summary>
        /// Parses a large multi-line string into a list of Commands, each parsed by ParseInput_SingleLine() method.
        /// </summary>
        /// <param name="inputFull">String input from the multi-line Text Box.</param>
        /// <returns>A list of Command objects, each containing an action and parameters.</returns>
        public List<Command> ParseInput_MultiLine(string inputFull)
        {
            List<Command> commandsList = new List<Command>();
            string[] inputSplitByLines = inputFull.Split('\n');
            inputSplitByLines.ToList().ForEach(input => commandsList.Add(ParseInput_SingleLine(input))); //ForEach command from System.Linq used here instead of a typical for-each loop
            return commandsList;
        }

        /// <summary>
        /// Parses the first word from ParseInput_SingleLine() to determine an action.
        /// </summary>
        /// <param name="input">String value for an Action.</param>
        /// <returns>An Action enum representing a command for the Command class.</returns>
        public Action ParseAction_Command(string input)
        {
            input = input.Split()[0].Trim().ToLower(); // Cleans the input param by removing any extra words (if any) in the input string, trims leading/trailing spaces, and makes it lowercase

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
            int[] inputIntArray = Array.ConvertAll(inputStringArray, int.Parse);

            return inputIntArray;
        }
    }
}
