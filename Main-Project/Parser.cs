using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace ASE_Assignment
{
    public class Parser
    {
        public Command ParseInput (string input) // string = "rectangle 100 140"
        {
            string[] words = input.ToLower().Split(' '); // words = ["rectangle", "100", "140"]

            if (words.Length > 3) // if words.Length > 3, throw new FormatException()
                throw new FormatException();

            string actionWord = words[0]; // actionWord = "rectangle"
            string[] actionValues = { words[1], words[2] }; // actionValues = ["100", "140"]

            Action action = ParseAction(actionWord); // action = Action.Rectangle
            int[] ints = ParseNumber(actionValues); // ints = [100, 140]

            Command command = new Command(action, ints); // command = new Command(Action.Rectangle, [100, 140])
            return command; 
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

            return Action.none;
        }

        public int[] ParseNumber (string[] input) // { str:100, str:150 }
        {
            int[] myInts = Array.ConvertAll(input, int.Parse);

            return myInts; // myInts = [100, 150]
        }

        //public Action OldParseInput(string input)
        //{
        //    input = input.ToLower();
        //    string[] splitCommand = input.Split(' ');

        //    switch (splitCommand[0])
        //    {
        //        case "rectangle":
        //            return Action.rectangle;
        //        case "square":
        //            return Action.square;
        //        case "circle":
        //            return Action.circle;
        //        case "triangle":
        //            return Action.triangle;
        //        case "move":
        //            return Action.move;
        //        case "clear":
        //            return Action.clear;
        //        case "reset":
        //            return Action.reset;
        //        default:
        //            return Action.none;
        //    }
        //}
    }
}
