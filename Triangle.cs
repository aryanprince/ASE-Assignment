using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Triangle : Shape
    {
        private int length;
        private System.Drawing.Point A { get; set; }
        private System.Drawing.Point B { get; set; }
        private System.Drawing.Point C { get; set; }
        private System.Drawing.Point D { get; set; }


        public override double calcArea()
        {
            throw new NotImplementedException();
        }

        public override double calcPerimeter()
        {
            throw new NotImplementedException();
        }

        public override void draw(Graphics g)
        {
            System.Drawing.Point[] vertices = { A, B, C, D };
            Pen p = new Pen(Color.Black, 2);
            g.DrawLines(p, vertices);
        }

        public Triangle(Color colourValue, int xValue, int yValue, int lengthValue) : base(colourValue, xValue, yValue)
        {
            length = lengthValue;

            A = new System.Drawing.Point(X, Y);
            B = new System.Drawing.Point(X, Y + lengthValue);
            C = new System.Drawing.Point(X + lengthValue, Y + lengthValue);
            D = new System.Drawing.Point(X, Y);
        }
    }
}
