using System.Drawing;

namespace ASE_Assignment
{
    class Line : Shape
    {
        public readonly Point _defaultToPosition = new Point(0, 0);
        public Point ToPosition { get; set; }

        public Line() : base()
        {
            ToPosition = _defaultToPosition;
        }
        public Line(Point currposition, bool fill, Color penColor, Point toPosition) : base(currposition, fill, penColor)
        {
            this.ToPosition = toPosition;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(PenColor, 2);
            g.DrawLine(p, Position.X, Position.Y, ToPosition.X, ToPosition.Y);
        }
    }
}
