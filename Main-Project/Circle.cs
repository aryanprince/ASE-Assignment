using System.Drawing;

namespace ASE_Assignment
{
    public class Circle : Shape
    {
        // Sets up default values for the blank constructor when the user doesn't pass any values. Currently unused in this program.
        private readonly int _defaultRadius = 85;

        // Properties for other values used in the class.
        private int Radius { get; set; }

        /// <summary>
        /// Blank constructor to create a Circle object with constant default dimension values.
        /// </summary>
        public Circle()
        {
            Radius = _defaultRadius;
        }

        /// <summary>
        /// Main constructor to create a Circle object with given parameters.
        /// </summary>
        /// <param name="position">Current position of the cursor.</param>
        /// <param name="fill">Current fill state of the cursor.</param>
        /// <param name="penColor">Current pen color from the cursor.</param>
        /// <param name="radius">Radius of the Circle.</param>
        public Circle(Point position, bool fill, Color penColor, int radius) : base(position, fill, penColor)
        {
            Radius = radius;
        }

        /// <summary>
        /// Draws a Circle on a WinForms control, may be a filled Circle based to cursor's fill state.
        /// </summary>
        /// <param name="g">Graphics context to draw a shape.</param>
        public override void Draw(Graphics g)
        {
            if (!Fill)
            {
                // Draws a circle
                var pen = new Pen(PenColor, 2);
                g.DrawEllipse(pen, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2); // Position if offset so that center of the circle is at the current cursor
                return; // Return to avoid drawing the fill
            }
            // Fills a circle
            var brush = new SolidBrush(PenColor);
            g.FillEllipse(brush, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
        }
    }
}
