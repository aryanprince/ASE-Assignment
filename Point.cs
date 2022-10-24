using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class Point
    {
        protected int x, y;

        public int X 
        { 
            get { return x; }
            set { x = value; } 
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public void moveTo(int toX, int toY)
        {
            X = toX;
            Y = toY;
        }

        public Point()
        {
        }

        public Point(int xValue, int yValue)
        {
            X = xValue;
            Y = yValue;
        }
    }
}
