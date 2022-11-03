using System.Drawing;

namespace ASE_Assignment
{
    public class Triangle : Shape
    {
        private int Length { get; set; }
        private Point A { get; set; }
        private Point B { get; set; }
        private Point C { get; set; }

        public Triangle(Point position, bool fill, Color penColor, int lengthValue) : base(position, fill, penColor)
        {
            Length = lengthValue;

            A = new Point(Position.X, Position.Y);
            B = new Point(Position.X, Position.Y + lengthValue);
            C = new Point(Position.X + lengthValue, Position.Y + lengthValue);
        }
        public override void draw(Graphics g)
        {
            Point[] vertices = { A, B, C };

            if (!Fill)
            {
                Pen p = new Pen(PenColor, 2);
                g.DrawPolygon(p, vertices);
                return; // Return to avoid drawing the fill
            }
            SolidBrush b = new SolidBrush(PenColor);
            g.FillPolygon(b, vertices);
        }
    }
}

