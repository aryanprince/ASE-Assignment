using System.Drawing;

namespace ASE_Assignment
{
    public class Circle : Shape
    {
        private static readonly int s_defaultRadius = 85;
        protected int Radius { get; set; }

        /// <summary>
        /// Draws a Circle using a Pen for border and a SolidBrush for fill
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(Color.Purple);
            g.FillEllipse(b, Position.X, Position.Y, Radius * 2, Radius * 2);
            g.DrawEllipse(p, Position.X, Position.Y, Radius * 2, Radius * 2);
        }

        public Circle() : this(s_defaultRadius)
        {

        }

        public Circle(int radius) : base()
        {
            Radius = radius;
        }

        public Circle(Point position, int radius) : base(position)
        {
            Radius = radius;
        }
    }
}
