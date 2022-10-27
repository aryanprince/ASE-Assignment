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

        public Triangle(Color colourValue, Point position, int lengthValue) : base(colourValue, position)
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
            Pen p = new Pen(Color.Black, 2);
            g.DrawLines(p, vertices);
        }
    }
}
