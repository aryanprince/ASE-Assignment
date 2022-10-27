using System;
using System.Drawing;

namespace ASE_Assignment
{
    public class Circle : Shape
    {
        private static readonly int defaultRadius = 85;
        protected int Radius { get; set; }

        public Circle() : this(defaultRadius)
        {

        }

        public Circle(int radius) : base()
        {
            Radius = radius;
        }

        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            Radius = radius;
        }

        /// <summary>
        /// Draws a Circle using a Pen for border and a SolidBrush for fill
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black,2);
            SolidBrush b = new SolidBrush(colour);
            g.FillEllipse(b, x, y, Radius * 2, Radius * 2);
            g.DrawEllipse(p, x, y, Radius * 2, Radius * 2);
        }

        public override string ToString()
        {
            return base.ToString() + "RADIUS: " + this.Radius;
        }
    }
}
