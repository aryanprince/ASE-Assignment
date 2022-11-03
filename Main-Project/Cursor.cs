using System.Drawing;

namespace ASE_Assignment
{
    public class Cursor : Shape
    {
        public Cursor() : base()
        {

        }

        public void moveTo(Point position)
        {
            Position = position;
        }

        public override void draw(Graphics g)
        {
            SolidBrush b = new SolidBrush(PenColor);
            g.FillRectangle(b, Position.X, Position.Y, 5, 5);
        }
    }
}
