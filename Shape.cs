using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        protected Color colour;
        protected int x, y;

        public Shape()
        {
            colour = Color.Green;
            x = 50;
            y = 50;
        }

        public Shape(Color colourValue, int xValue, int yValue)
        {
            colour = colourValue;
            x = xValue;
            y = yValue;
        }

        public abstract void draw(Graphics g);
        public abstract double calcArea();
        public abstract double calcPerimeter();

        public override string ToString()
        {
            return base.ToString() + " ===> POS: " + this.x + "," + this.y + " ===> ";
        }
    }
}
