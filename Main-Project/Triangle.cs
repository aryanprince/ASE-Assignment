using System.Drawing;

namespace ASE_Assignment
{
    public class Triangle : Shape
    {
        private int length;
        private Point A { get; set; }
        private Point B { get; set; }
        private Point C { get; set; }
        private Point D { get; set; }

        public Triangle(Point position, bool fill, Color penColor, int lengthValue) : base(position, fill, penColor)
        {
            length = lengthValue;

            A = new Point(Position.X, Position.Y);
            B = new Point(Position.X, Position.Y + lengthValue);
            C = new Point(Position.X + lengthValue, Position.Y + lengthValue);
            D = new Point(Position.X, Position.Y);
        }
        public override void draw(Graphics g)
        {
            System.Drawing.Point[] vertices = { A, B, C, D };
            if (Fill)
            {
                SolidBrush b = new SolidBrush(PenColor);
                g.FillPolygon(b, vertices);
            }
            else
            {
                Pen p = new Pen(PenColor, 2);
                g.DrawPolygon(p, vertices);
            }
        }
    }
}

