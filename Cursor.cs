﻿using System;
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
            throw new NotImplementedException();
        }
    }
}
