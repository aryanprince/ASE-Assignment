using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        protected Point s_defaultPosition = new Point(0,0);
        public Point Position { get; set; }
        
        protected int s_defaultFill = 1;
        public int Fill { get; set; }

        public Shape()
        {
            Position = s_defaultPosition;
            Fill = s_defaultFill;
        }

        public Shape(Point position)
        {
            Position = position;
            Fill = s_defaultFill;
        }

        public abstract void draw(Graphics g);
    }
}
