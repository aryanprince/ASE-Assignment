using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class xShape
    {
        private int x;
        private int y;
        
        public virtual double Area()
        {
            return 0.0;
        }

        public virtual double Perimeter()
        {
            return 0.0;
        }

        public xShape(int xValue, int yValue)
        {
            x = xValue;
            y = yValue;
        }

        public xShape()
        {

        }
    }
}
