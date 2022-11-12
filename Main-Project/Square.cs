﻿using System.Drawing;

namespace ASE_Assignment
{
    public class Square : Rectangle
    {
        private readonly int _defaultSideLength = 100;

        private int SideLength { get; set; }

        public Square()
        {
            SideLength = _defaultSideLength;
        }

        public Square(Point position, bool fill, Color penColor, int sideLength) : base(position, fill, penColor, sideLength, sideLength)
        {
            SideLength = sideLength;
        }

        public override void Draw(Graphics g)
        {
            if (!Fill)
            {
                // Draws a rectangle
                var pen = new Pen(PenColor, 2);
                g.DrawRectangle(pen, Position.X, Position.Y, SideLength, SideLength);
                return; // Return to avoid drawing the fill
            }
            // Fills a rectangle
            var brush = new SolidBrush(PenColor);
            g.FillRectangle(brush, Position.X, Position.Y, SideLength, SideLength);
        }
    }
}
