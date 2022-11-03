using System.Drawing;

namespace ASE_Assignment
{
    public class Circle : Shape
    {
        private readonly int _defaultRadius = 85;
        protected int Radius { get; set; }

        public Circle()
        {
            Radius = _defaultRadius;
        }

        public Circle(Point position, bool fill, Color penColor, int radius) : base(position, fill, penColor)
        {
            Radius = radius;
        }

        /// <summary>
        /// Draws a Circle using a Pen for border and a SolidBrush for fill
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            if (!Fill)
            {
                // Draws a circle
                Pen p = new Pen(PenColor, 2);
                g.DrawEllipse(p, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2); // Center of the circle is at the current cursor
                return; // Return to avoid drawing the fill
            }
            // Fills a circle
            SolidBrush b = new SolidBrush(PenColor);
            g.FillEllipse(b, Position.X - Radius, Position.Y - Radius, Radius * 2, Radius * 2);
        }
    }
}
