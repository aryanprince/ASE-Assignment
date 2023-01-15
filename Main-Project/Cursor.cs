﻿using System.Drawing;

namespace ASE_Assignment
{
    /// <summary>
    /// Cursor to manage the current cursor state for drawing shapes.
    /// Implements the <see cref="ASE_Assignment.Shape" /> parent class.
    /// </summary>
    /// <seealso cref="ASE_Assignment.Shape" />
    public class Cursor : Shape
    {
        /// <summary>
        /// Blank constructor to create a Cursor object.
        /// </summary>
        public Cursor() : base()
        {

        }

        /// <summary>
        /// Updates the cursor's position the given Point value.
        /// </summary>
        /// <param name="position">New position of the cursor.</param>
        public void MoveTo(Point position)
        {
            Position = position;
        }

        public void ChangePenColor(Color penColor)
        {
            PenColor = penColor;
        }

        public void ChangeFillState(bool fillState)
        {
            Fill = fillState;
        }

        /// <summary>
        /// Draws a cursor on a WinForms control.
        /// </summary>
        /// <param name="g">Graphics context to draw a shape.</param>
        public override void Draw(Graphics g)
        {
            var b = new SolidBrush(PenColor);
            g.FillRectangle(b, Position.X, Position.Y, 5, 5);
        }
    }
}
