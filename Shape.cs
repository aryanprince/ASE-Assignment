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

        public Shape(Color colourValue, int xPos, int yPos) : base(xPos, yPos)
        {
            colour = colourValue;
        }

        public abstract void draw(Graphics g);
    }
}
