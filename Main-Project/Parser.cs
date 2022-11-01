using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace ASE_Assignment
{
    public class Parser
    {
        public Command ParseInput(string input) // ParseInput is a method that takes a string as input and returns a Command object
        {
            string[] words = input.ToLower().Split(' '); // Split the input string into an array of strings, separated by spaces

            if (words.Length > 3) // Invalid when more than 3 words
                throw new FormatException();

            string actionWord = words[0]; 
            string[] actionValues = { words[1], words[2] }; 

            Action action = ParseAction(actionWord); // Set the ActionWord property of the Command object to the Action enum value returned by ParseAction
            int[] ints = ParseNumber(actionValues); // Set the ActionValues property of the Command object to the array of integers returned by ParseValues

            Command command = new Command(action, ints); // Create a new Command object
            return command; // Return the Command object
        }

        public Action ParseAction (string input)
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

        public int[] ParseNumber (string[] input)
        {
            int[] myInts = Array.ConvertAll(input, int.Parse);

            return myInts;
        }
    }
}
