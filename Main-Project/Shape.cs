using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        public static readonly Point s_defaultPosition = new Point(0, 0);
        public Point Position { get; set; }

        //!test
        //!trying out fill state
        public bool Fill { get; set; }

        public Shape()
        {

        }

        public Shape(Point position, bool fill)
        {
            Position = position;
            Fill = fill;
        }

        public abstract void draw(Graphics g);
    }
}
