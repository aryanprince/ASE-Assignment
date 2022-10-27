using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        protected Color s_defaultColour = Color.Green;
        protected Point s_defaultPosition = new Point(0,0);
        //protected int x, y;
        public Color Color { get; set; }
        public Point Position { get; set; }

        //public int X
        //{
        //    get { return x; }
        //    set { x = value; }
        //}
        //public int Y
        //{
        //    get { return y; }
        //    set { y = value; }
        //}

        public void moveTo(Point position)
        {
            Position = position;
        }

        public Shape()
        {
            Color = Color.Green;
        }

        public Shape(Color colourValue, Point position)
        {
            Color = colourValue;
            Position = position;
        }

        public abstract void draw(Graphics g);
    }
}
