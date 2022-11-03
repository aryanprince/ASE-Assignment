using System.Drawing;

namespace ASE_Assignment
{
    public class Rectangle : Shape
    {
        private readonly int _defaultLength = 100;
        private readonly int _defaultHeight = 150;
        protected int Length { get; set; }
        protected int Height { get; set; }

        public Rectangle() : base()
        {
            Length = _defaultLength;
            Height = _defaultHeight;
        }

        public Rectangle(Point position, bool fill, Color penColor, int length, int height) : base(position, fill, penColor)
        {
            Length = length;
            Height = height;
        }

        /// <summary>
        /// Draws a Rectangle using a Pen for border and a SolidBrush for fill
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            // Fills a rectangle
            if (!Fill)
            {
                // Draws a rectangle
                Pen p = new Pen(PenColor, 2);
                g.DrawRectangle(p, Position.X, Position.Y, Length, Height);
                return; // Return to avoid drawing the fill
            }
            // Fills a rectangle
            SolidBrush b = new SolidBrush(PenColor);
            g.FillRectangle(b, Position.X, Position.Y, Length, Height);
        }
    }
}
