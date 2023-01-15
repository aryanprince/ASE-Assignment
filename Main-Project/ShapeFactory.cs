using System;
using System.Drawing;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that utilizes the Factory pattern to create shape objects.
    /// </summary>
    public class ShapeFactory
    {
        // Single instance of the ShapeFactory class.
        private static ShapeFactory _instance;

        // Private constructor to prevent instantiation using the new keyword.
        private ShapeFactory() { }

        // Returns only the single instance of the ShapeFactory class, creating it the first time.
        public static ShapeFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShapeFactory();
                }
                return _instance;
            }
        }

        public Shape CreateShape(CommandShapeNum commandShape, Point position, bool fill, Color penColor)
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
                    throw new ArgumentException("Invalid command!");
            }
        }
    }
}
