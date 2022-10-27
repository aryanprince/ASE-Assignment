﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Rectangle : Shape
    {
        
        private static readonly int s_defaultLength = 100;
        private static readonly int s_defaultHeight = 150;
        protected int Length { get; set; }
        protected int Height { get; set; }

        public Rectangle() : this(s_defaultLength, s_defaultHeight)
        {
            
        }

        public Rectangle(int length, int height) : base()
        {
            Length = length;
            Height = height;
        }

        public Rectangle(Color colour, Point position, int length, int height) : base(colour, position)
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
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(Color);
            g.FillRectangle(b, Position.X, Position.Y, Length, Height);
            g.DrawRectangle(p, Position.X, Position.Y, Length, Height);
        }
    }
}
