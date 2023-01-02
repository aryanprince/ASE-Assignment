using System;
using System.Drawing;

namespace ASE_Assignment
{
    public class ShapeFactory
    {
        public Shape CreateShape(CommandShape commandShape, Point position, bool fill, Color penColor)
        {
            switch (commandShape.ActionWord)
            {
                case Action.rectangle:
                    return new Rectangle(position, fill, penColor, commandShape.ActionValues[0], commandShape.ActionValues[1]);
                case Action.square:
                    return new Square(position, fill, penColor, commandShape.ActionValues[0]);
                case Action.circle:
                    return new Circle(position, fill, penColor, commandShape.ActionValues[0]);
                case Action.triangle:
                    return new Triangle(position, fill, penColor, commandShape.ActionValues[0]);
                case Action.drawto:
                    return new Line(position, fill, penColor, new Point(commandShape.ActionValues[0], commandShape.ActionValues[1]));
                default:
                    throw new Exception("Invalid command!");
            }
        }
    }
}
