using System.Drawing;

namespace ASE_Assignment
{
    /// <summary>
    /// A parent class that serves as the foundation for all shapes and implements the <see cref="IShape" /> interface.
    /// </summary>
    /// <seealso cref="IShape" />
    public abstract class Shape : IShape
    {
        // Sets up default values for the blank constructor when the user doesn't pass any values. Currently unused in this program.
        public readonly Point DefaultPosition = new Point(0, 0);
        public readonly bool DefaultFill = false;
        public readonly Color DefaultPenColor = Color.Red;

        // Properties for other values used in the class.
        public Point Position { get; set; } // Position of the cursor
        public bool Fill { get; set; } // Fill state of any shapes being drawn
        public Color PenColor { get; set; } // PenColor for drawing any of the shapes

        /// <summary>
        /// Blank constructor with some default values.
        /// </summary>
        protected Shape()
        {
            Position = DefaultPosition;
            Fill = DefaultFill;
            PenColor = DefaultPenColor;
        }

        /// <summary>
        /// Main constructor for the Shape object. This is also a base class to all other shapes.
        /// </summary>
        /// <param name="position">Current position of the cursor.</param>
        /// <param name="fill">Current fill state of the cursor.</param>
        /// <param name="penColor">Current pen color from the cursor.</param>
        protected Shape(Point position, bool fill, Color penColor)
        {
            Position = position;
            Fill = fill;
            PenColor = penColor;
        }

        /// <summary>
        /// An abstract class to draw shapes. All inherited shape classes override this to draw specific shapes.
        /// </summary>
        /// <param name="g">Graphics context to draw a shape.</param>
        public abstract void Draw(Graphics g);
    }
}
