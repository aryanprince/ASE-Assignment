using System.Drawing;

namespace ASE_Assignment
{
    public class Triangle : Shape
    {
        // Sets up default values for the blank constructor when the user doesn't pass any values. Currently unused in this program.
        private readonly int _defaultLength = 125;

        // Properties for other values used in the class.
        public int Length { get; set; } // Stores the side length of the Triangle

        // Creates 3 Point properties to store coordinates of Triangle vertices
        private Point A { get; set; }
        private Point B { get; set; }
        private Point C { get; set; }

        /// <summary>
        /// Blank constructor to create a right-angled Triangle object with constant default dimension values.
        /// </summary>
        public Triangle() : base()
        {
            Length = _defaultLength;
            SetupTriangleVertices(Length);
        }

        /// <summary>
        /// Main constructor to create a right-angled Triangle object with given parameters.
        /// </summary>
        /// <param name="position">Current position of the cursor.</param>
        /// <param name="fill">Current fill state of the cursor.</param>
        /// <param name="penColor">Current pen color from the cursor.</param>
        /// <param name="lengthValue">Length of the sides of the Triangle.</param>
        public Triangle(Point position, bool fill, Color penColor, int lengthValue) : base(position, fill, penColor)
        {
            Length = lengthValue;
            SetupTriangleVertices(Length);
        }

        /// <summary>
        /// Sets up the vertices to make a right-angled Triangle.
        /// </summary>
        /// <param name="length">Length of the sides of the Triangle, used to setup the vertices.</param>
        private void SetupTriangleVertices(int length)
        {
            A = new Point(Position.X, Position.Y);
            B = new Point(Position.X, Position.Y + length);
            C = new Point(Position.X + length, Position.Y + length);
        }

        /// <summary>
        /// Draws a Triangle on a WinForms control, may be a filled Triangle based to cursor's fill state.
        /// </summary>
        /// <param name="g">Graphics context to draw a shape.</param>
        public override void Draw(Graphics g)
        {
            // Creates an array of Points
            Point[] vertices = { A, B, C };

            if (!Fill)
            {
                // Draws a triangle
                var pen = new Pen(PenColor, 2);
                g.DrawPolygon(pen, vertices);
                pen.Dispose(); // Dispose of the pen to avoid memory leaks
                return; // Return to avoid drawing the fill
            }
            // Fills a triangle
            var brush = new SolidBrush(PenColor);
            g.FillPolygon(brush, vertices);
            brush.Dispose(); // Dispose of the brush to avoid memory leaks
        }
    }
}