using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        protected Color colour;
        protected int x, y;

        public Shape()
        {
            colour = Color.Red;
            x = y = 100;
        }

        public Shape(Color colourValue, int xValue, int yValue)
        {
            colour = colourValue;
            x = xValue;
            y = yValue;
        }
        
        public abstract double calcArea();
        public abstract double calcPerimeter();
        public abstract void draw(Graphics g);
    }
}
