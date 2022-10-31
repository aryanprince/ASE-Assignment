using System;

namespace ASE_Assignment
{
    public class ShapeFactory
    {
        public Shape CreateShape(Command command)
        {
            switch (command.ActionWord)
            {
                case Action.rectangle:
                    return new Rectangle(command.ActionValues[0], command.ActionValues[1]);
                case Action.circle:
                    return new Circle(command.ActionValues[0]);
                //case Action.move:
                //    return new Move(command.ActionValues[0], command.ActionValues[1]);
                default:
                    throw new ArgumentException();
            }
        }
        
        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}

// 1. User types "rectangle 100 150"
// 2. Parser takes in "rectangle 100 150" as input
// 3. Parser spits out an object of Rectangle @ cursor 0,0 and default dimensions
// 4. Draw this Rectangle in Form.cs
