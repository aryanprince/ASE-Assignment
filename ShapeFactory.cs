namespace ASE_Assignment
{
    public class ShapeFactory
    {
        public Shape CreateShape(string input)
        {
            string[] splitCommand = input.Split(' ');

            if (splitCommand[0] == "rectangle")
            {
                return new Rectangle(int.Parse(splitCommand[1]), int.Parse(splitCommand[2]));
            }
            if (splitCommand[0] == "circle")
            {
                return new Circle(int.Parse(splitCommand[1]));
            }
            return null;
        }
    }
}

// 1. User types "rectangle 100 150"
// 2. Parser takes in "rectangle 100 150" as input
// 3. Parser spits out an object of Rectangle @ cursor 0,0 and default dimensions
// 4. Draw this Rectangle in Form.cs
