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

        public override double Area()
        {
            return radius * radius * Math.PI;
        }

        public override double Perimeter()
        {
            return 2.0 * Math.PI * radius;
        }

        public xCircle(int xValue, int yValue, double radiusValue) : base(xValue, yValue)
        {
            radius = radiusValue;
        }

        public xCircle()
        {

        }
    }
}
