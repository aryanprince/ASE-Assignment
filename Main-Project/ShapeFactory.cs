using System;

namespace ASE_Assignment
{
    public class ShapeFactory
    {
        public Shape CreateShape(string input)
        {
            string[] splitCommand = input.Split(' ');

            if (splitCommand[0] == "rectangle")
            {
                //if (IsDigitsOnly(splitCommand[1]) == true && IsDigitsOnly(splitCommand[2]) == true)
                //    return new Rectangle(int.Parse(splitCommand[1]), int.Parse(splitCommand[2]));
                //else
                //    throw new FormatException();
                return new Rectangle(int.Parse(splitCommand[1]), int.Parse(splitCommand[2]));
            }
            if (splitCommand[0] == "circle")
            {
                return new Circle(int.Parse(splitCommand[1]));
            }
            return null;
        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}

// 1. User types "rectangle 100 150"
// 2. Parser takes in "rectangle 100 150" as input
// 3. Parser spits out an object of Rectangle @ cursor 0,0 and default dimensions
// 4. Draw this Rectangle in Form.cs
