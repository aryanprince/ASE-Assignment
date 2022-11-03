﻿using System.Drawing;

namespace ASE_Assignment
{
    class Line : Shape
    {
        public static readonly Point s_defaultToPosition = new Point(0, 0);
        public Point ToPosition { get; set; }

        public Line(Point currposition, bool fill, Point toPosition) : base(currposition, fill)
        {
            this.ToPosition = toPosition;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawLine(p, Position.X, Position.Y, ToPosition.X, ToPosition.Y);
        }
    }
}
