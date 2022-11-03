using System;
using System.Collections.Generic;

namespace ASE_Assignment
{
    public class Parser
    {
        public Command ParseInput(string inputFull_FromCommandLine) // ParseInput is a method that takes a string as input and returns a Command object
        {
            string[] inputSplit = inputFull_FromCommandLine.ToLower().Split(' '); // Split the input string into an array of strings, separated by spaces

            if (inputSplit.Length > 3) // Invalid when more than 3 words
                throw new FormatException();

            string stringWord = inputSplit[0];
            //xstring[] stringParams = { inputSplit[1], inputSplit[2] };


            List<string> stringParamsList = new List<string>();
            for (int i = 1; i < inputSplit.Length; i++)
            {
                stringParamsList.Add(inputSplit[i]);
            }
            string[] stringParams = stringParamsList.ToArray();



            Action actionWord = ParseActionWord(stringWord); // Set the ActionWord property of the Command object to the Action enum value returned by ParseAction
            int[] actionParams = ParseActionParamsInt(stringParams); // Set the ActionValues property of the Command object to the array of integers returned by ParseValues

            return new Command(actionWord, actionParams); // Creates and returns a Command object
        }

        public Action ParseActionWord(string input)
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

        public int[] ParseActionParamsInt(string[] input)
        {
            int[] myInts = Array.ConvertAll(input, int.Parse);

            return myInts;
        }
    }
}
