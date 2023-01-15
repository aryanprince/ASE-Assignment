using System.Drawing;

namespace ASE_Assignment
{
    /// <summary>
    /// A class that implements the <see cref="Rectangle" /> class, which inherits the <see cref="Shape" /> parent class, and is used to create <see cref="Square" /> objects and draw them on a WinForms control.
    /// </summary>
    /// <seealso cref="Rectangle" />
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
