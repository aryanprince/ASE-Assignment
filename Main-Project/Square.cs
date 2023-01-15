using System.Drawing;

namespace ASE_Assignment
{
    /// <summary>
    /// Used to create Square objects and drawing rectangles on a WinForms control.
    /// Implements the <see cref="ASE_Assignment.Rectangle" /> class, which inherits the <see cref="ASE_Assignment.Shape" /> parents class.
    /// </summary>
    /// <seealso cref="ASE_Assignment.Rectangle" />
    public class Square : Rectangle
    {
        private readonly int _defaultSideLength = 100;

        private int SideLength { get; set; }

        public Square()
        {
            SideLength = _defaultSideLength;
        }

        public Square(Point position, bool fill, Color penColor, int sideLength) : base(position, fill, penColor, sideLength, sideLength)
        {
            SideLength = sideLength;
        }

        public override void Draw(Graphics g)
        {
            if (!Fill)
            {
                // Draws a rectangle
                var pen = new Pen(PenColor, 2);
                g.DrawRectangle(pen, Position.X, Position.Y, SideLength, SideLength);
                pen.Dispose(); // Dispose of the pen to avoid memory leaks
                return; // Return to avoid drawing the fill
            }
            // Fills a rectangle
            var brush = new SolidBrush(PenColor);
            g.FillRectangle(brush, Position.X, Position.Y, SideLength, SideLength);
            brush.Dispose(); // Dispose of the brush to avoid memory leaks
        }
    }
}
