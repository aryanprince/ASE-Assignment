using System.Drawing;

namespace ASE_Assignment
{
    public class Rectangle : Shape
    {
        // Sets up default values for the blank constructor when the user doesn't pass any values. Currently unused in this program.
        private readonly int _defaultLength = 100;
        private readonly int _defaultHeight = 150;

        // Properties for other values used in the class.
        private int Length { get; set; }
        private int Height { get; set; }

        /// <summary>
        /// Blank constructor to create a Rectangle object with constant default dimension values.
        /// </summary>
        public Rectangle() : base()
        {
            Length = _defaultLength;
            Height = _defaultHeight;
        }

        /// <summary>
        /// Main constructor to create a Rectangle object with given parameters.
        /// </summary>
        /// <param name="position">Current position of the cursor.</param>
        /// <param name="fill">Current fill state of the cursor.</param>
        /// <param name="penColor">Current pen color from the cursor.</param>
        /// <param name="length">Length of the Rectangle.</param>
        /// <param name="height">Height of the Rectangle.</param>
        public Rectangle(Point position, bool fill, Color penColor, int length, int height) : base(position, fill, penColor)
        {
            Length = length;
            Height = height;
        }

        /// <summary>
        /// Draws a Rectangle on a WinForms control, may be a filled Rectangle based to cursor's fill state.
        /// </summary>
        /// <param name="g">Graphics context to draw a shape.</param>
        public override void Draw(Graphics g)
        {
            if (!Fill)
            {
                // Draws a rectangle
                var pen = new Pen(PenColor, 2);
                g.DrawRectangle(pen, Position.X, Position.Y, Length, Height);
                return; // Return to avoid drawing the fill
            }
            // Fills a rectangle
            var brush = new SolidBrush(PenColor);
            g.FillRectangle(brush, Position.X, Position.Y, Length, Height);
        }
    }
}
