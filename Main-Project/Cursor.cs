using System.Drawing;

namespace ASE_Assignment
{
    public class Cursor : Shape
    {
        /// <summary>
        /// Blank constructor to create a Cursor object.
        /// </summary>
        public Cursor() : base()
        {

        }

        /// <summary>
        /// Updates the cursor's position the given Point value.
        /// </summary>
        /// <param name="position">New position of the cursor.</param>
        public void MoveTo(Point position)
        {
            Position = position;
        }

        /// <summary>
        /// Draws a cursor on a WinForms control.
        /// </summary>
        /// <param name="g">Graphics context to draw a shape.</param>
        public override void Draw(Graphics g)
        {
            var b = new SolidBrush(PenColor);
            g.FillRectangle(b, Position.X, Position.Y, 5, 5);
        }
    }
}
