using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape : Point
    {
        protected Color colour;

        public Shape() : base()
        {
            colour = Color.Green;
        }

        public Shape(Color colourValue, int xValue, int yValue) : base(xValue, yValue)
        {
            colour = colourValue;
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
