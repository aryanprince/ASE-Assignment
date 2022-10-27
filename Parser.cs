using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Parser
    {
        public ValidCommands ParseInput(string input)
        {
            input = input.ToLower();
            string[] splitCommand = input.Split(' ');

            switch (splitCommand[0])
            {
                case "rectangle":
                    return ValidCommands.rectangle;
                case "square":
                    return ValidCommands.square;
                case "circle":
                    return ValidCommands.circle;
                case "triangle":
                    return ValidCommands.triangle;
                case "move":
                    return ValidCommands.move;
                case "clear":
                    return ValidCommands.clear;
                case "reset":
                    return ValidCommands.reset;
                default:
                    return ValidCommands.none;
            }
        }
    }
}
