using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        public Point Position { get; set; }
        public static readonly Point s_defaultPosition = new Point(0, 0);

        public bool Fill { get; set; }
        public static readonly bool s_defaultFill = false;

        public Color PenColor { get; set; }
        public static readonly Color s_defaultPenColor = Color.Red;

        public Shape()
        {
            Position = s_defaultPosition;
            Fill = s_defaultFill;
            PenColor = s_defaultPenColor;
        }

        public Shape(Point position, bool fill, Color penColor)
        {
            Position = position;
            Fill = fill;
            PenColor = penColor;
        }

        public abstract void draw(Graphics g);
    }
}
