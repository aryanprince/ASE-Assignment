using System;
using System.Drawing;
using System.Windows.Forms;

namespace ASE_Assignment
{
    public class ShapeFactory
    {
        public Shape CreateShape(Command command, Point position, bool fill, Color penColor, Label errorLabel)
        {
            switch (command.ActionWord)
            {
                case Action.rectangle:
                    {
                        try
                        {
                            return new Rectangle(position, fill, penColor, command.ActionValues[0], command.ActionValues[1]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            errorLabel.Text = "Invalid command!\nRectangle requires 2 parameters.";
                            break;
                        }
                    }
                case Action.square:
                    return new Rectangle(position, fill, penColor, command.ActionValues[0], command.ActionValues[0]);
                case Action.circle:
                    return new Circle(position, fill, penColor, command.ActionValues[0]);
                case Action.triangle:
                    return new Triangle(position, fill, penColor, command.ActionValues[0]);
                case Action.drawto:
                    return new Line(position, fill, penColor, new Point(command.ActionValues[0], command.ActionValues[1]));
                default:
                    break; ;
            }
            return null;
        }
    }
}
