﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assignment
{
    public class xRectangle : xShape
    {
        private int length;
        private int height;
        
        public xRectangle(int xValue, int yValue, int lengthValue, int heightValue) : base (xValue, yValue)
        {
            length = lengthValue;
            height = heightValue;
        }
        
        public xRectangle()
        {

        }
    }
}
