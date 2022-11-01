using System;

namespace ASE_Assignment
{
    public class ShapeFactory
    {
        public Shape CreateShape(Command command, Cursor cursor)
        {
            switch (command.ActionWord)
            {
                case Action.rectangle:
                    return new Rectangle(cursor.Position, command.ActionValues[0], command.ActionValues[1]);
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
