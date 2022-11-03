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
            if (Fill)
            {
                // Fills a circle
                SolidBrush b = new SolidBrush(Color.Purple);
                g.FillEllipse(b, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);

            }
            else
            {
                // Draws a circle
                Pen p = new Pen(Color.Black, 2);
                g.DrawEllipse(p, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2); // Center of the circle is at the current cursor
            }
        }

        public Circle() : this(s_defaultRadius)
        {

        }

        public Circle(int radius) : base()
        {
            Radius = radius;
        }

        public Circle(Point position, bool fill, int radius) : base(position, fill)
        {
            Radius = radius;
            Fill = Fill;
        }
    }
}
