using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        protected Color colour;
        protected int x, y;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public void moveTo(int toX, int toY)
        {
            X = toX;
            Y = toY;
        }

        public Shape()
        {
            colour = Color.Green;
        }

        public Shape(Color colourValue, int xPos, int yPos)
        {
            colour = colourValue;
            X = xPos;
            Y = yPos;
        }

        public abstract void draw(Graphics g);
    }
}
