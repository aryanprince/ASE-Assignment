using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        public static readonly Point s_defaultPosition = new Point(0, 0);
        public Point Position { get; set; }

        public Shape() : this(s_defaultPosition)
        {

        }

        public Shape(Point position)
        {
            Position = position;
        }

        public abstract void draw(Graphics g);
    }
}
