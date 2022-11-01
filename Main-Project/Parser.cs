using System;

namespace ASE_Assignment
{
    public class Parser
    {
        public Command ParseInput(string inputFull) // ParseInput is a method that takes a string as input and returns a Command object
        {
            string[] inputSplit = inputFull.ToLower().Split(' '); // Split the input string into an array of strings, separated by spaces

            if (inputSplit.Length > 3) // Invalid when more than 3 words
                throw new FormatException();

            string stringWord = inputSplit[0];
            string[] stringParams = { inputSplit[1], inputSplit[2] };

            Action action = ParseActionWord(stringWord); // Set the ActionWord property of the Command object to the Action enum value returned by ParseAction
            int[] ints = ParseActionParamsInt(stringParams); // Set the ActionValues property of the Command object to the array of integers returned by ParseValues
            Command command = new Command(action, ints); // Create a new Command object

            return command; // Return the Command object
        }

        public Action ParseActionWord(string input)
        {
            input = input.Split()[0]; // These two lines 'cleans' the input param by removing any extra words if any in the input string

            if (input == "rectangle")
            {
                return Action.rectangle;
            }
            if (input == "circle")
            {
                return Action.circle;
            }
            if (input == "move")
            {
                return Action.move;
            }
            if (input == "fill")
            {
                return Action.fill;
            }

            return Action.none;
        }

        public int[] ParseActionParamsInt(string[] input)
        {
            int[] myInts = Array.ConvertAll(input, int.Parse);

            return myInts;
        }
    }
}
