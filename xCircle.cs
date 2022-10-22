using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class xCircle : xShape
    {
        private double radius;

        public xCircle(int xValue, int yValue, double radiusValue) : base(xValue, yValue)
        {
            radius = radiusValue;
        }

        public xCircle()
        {

        }
    }
}
