using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        protected Point s_defaultPosition = new Point(0,0);
        public Point Position { get; set; }

        public Shape()
        {
            
        }

        public Shape(Point position)
        {
            Position = position;
        }

        public abstract void draw(Graphics g);
    }
}
