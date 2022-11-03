using System.Drawing;

namespace ASE_Assignment
{
    public abstract class Shape
    {
        private readonly Point _defaultPosition = new Point(0, 0);
        private readonly bool _defaultFill = false;
        private readonly Color _defaultPenColor = Color.Red;

        public Point Position { get; set; }
        public bool Fill { get; set; }
        public Color PenColor { get; set; }

        public Shape()
        {
            Position = _defaultPosition;
            Fill = _defaultFill;
            PenColor = _defaultPenColor;
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
