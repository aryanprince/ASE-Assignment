using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Rectangle : Shape
    {
        int length;
        int height;

        public Rectangle() : base()
        {
            length = 50;
            height = 50;
        }

        public Rectangle(Color colourValue, int xValue, int yValue, int lengthValue, int heightValue) : base(colourValue, xValue, yValue)
        {
            length = lengthValue;
            height = heightValue;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(colour);
            g.FillRectangle(b, x, y, length, height);
            g.DrawRectangle(p, x, y, length, height);
        }

        public override double calcArea()
        {
            return length * height;
        }

        public override double calcPerimeter()
        {
            return 2.0 * (length + height);
        }

        public override string ToString() //all classes inherit from object and ToString() is abstract in object
        {
            return base.ToString() + "DIMENSIONS: " + this.length + "," + this.height;
        }
    }
}
