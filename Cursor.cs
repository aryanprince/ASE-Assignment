using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Cursor : Shape
    {
        public Cursor()
        {

        }
        
        public void moveTo(Point position)
        {
            Position = position;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(Color.Red);
            g.FillRectangle(b, Position.X, Position.Y, 5, 5);
            g.DrawRectangle(p, Position.X, Position.Y, 5, 5);
        }
    }
}
