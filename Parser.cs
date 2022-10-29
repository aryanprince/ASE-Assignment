using System;
using System.Collections.Generic;

namespace ASE_Assignment
{
    public class Parser
    {
        public ValidCommandsEnum ParseInput(string input)
        {
            input = input.ToLower();
            string[] splitCommand = input.Split(' ');

            switch (splitCommand[0])
            {
                case "rectangle":
                    return ValidCommandsEnum.rectangle;
                case "square":
                    return ValidCommandsEnum.square;
                case "circle":
                    return ValidCommandsEnum.circle;
                case "triangle":
                    return ValidCommandsEnum.triangle;
                case "move":
                    return ValidCommandsEnum.move;
                case "clear":
                    return ValidCommandsEnum.clear;
                case "reset":
                    return ValidCommandsEnum.reset;
                default:
                    return ValidCommandsEnum.none;
            }
        }
    }
}
