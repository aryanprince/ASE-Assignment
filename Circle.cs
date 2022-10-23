using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Circle : Shape
    {
        int radius;

        public Circle() : base()
        {
            radius = 50;
        }
        
        public Circle(Color colour, int x, int y, int radiusValue) : base(colour, x, y)
        {
            radius = radiusValue;
        }

        /// <summary>
        /// Draws a Circle using a Pen for border and a SolidBrush for fill
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black,2);
            SolidBrush b = new SolidBrush(colour);
            g.FillEllipse(b, x, y, radius * 2, radius * 2);
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);
        }

        public override double calcArea()
        {
            return radius * radius * Math.PI;
        }

        public override double calcPerimeter()
        {
            return 2.0 * Math.PI * radius;
        }

        public override string ToString()
        {
            return base.ToString() + "RADIUS: " + this.radius;
        }
    }
}
