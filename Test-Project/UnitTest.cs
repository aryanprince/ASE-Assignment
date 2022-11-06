using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ASE_Assignment.Tests
{

    [TestClass()]
    public class DrawingRectangles
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingCircleWithParameters()
        {
            //arrange
            string input = "rectangle 100 150";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.circle, action);
        }

        [TestMethod()]
        public void ParseAction_DrawingCircleWithZeroParameters()
        {
            //arrange
            string input = "rectangle";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
            Assert.AreNotEqual(Action.circle, action);
        }

        [TestMethod()]
        public void ParseInput_DrawingRectangleWithParameters()
        {
            //arrange
            string input = "rectangle 100 150";

            // act
            Command command = parser.ParseInput_SingleLine(input);

            // assert
            Assert.AreEqual(Action.rectangle, command.ActionWord);
            Assert.AreNotEqual(Action.circle, command.ActionWord);
            Assert.AreNotEqual(Action.square, command.ActionWord);
            Assert.AreEqual(100, command.ActionValues[0]);
            Assert.AreEqual(150, command.ActionValues[1]);
            Assert.AreEqual(2, command.ActionValues.Length);
        }

        [TestMethod()]
        public void ParseInput_DrawingRectangleWithFillOn()
        {
            {
                //arrange
                string input = "rectangle 100 150";

                // act
                Command command = parser.ParseInput_SingleLine(input);

                // assert
                Assert.AreEqual(Action.rectangle, command.ActionWord);
                Assert.AreEqual(100, command.ActionValues[0]);
                Assert.AreEqual(150, command.ActionValues[1]);
                Assert.AreEqual(2, command.ActionValues.Length);

                //arrange
                input = "fill on";

                // act
                command = parser.ParseInput_SingleLine(input);

                // assert
                Assert.AreEqual(Action.fill, command.ActionWord);
            }
        }
    }

    [TestClass()]
    public class DrawingCircles
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingCircleWithParameters()
        {
            //arrange
            string input = "circle 100 150";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
        }

        [TestMethod()]
        public void ParseAction_DrawingCircleWithZeroParameters()
        {
            //arrange
            string input = "circle";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
        }

        [TestMethod()]
        public void ParseInput_DrawingCircleWithParameters()
        {
            //arrange
            string input = "circle 100 150";

            // act
            Command command = parser.ParseInput_SingleLine(input);

            // assert
            Assert.AreEqual(Action.circle, command.ActionWord);
            Assert.AreEqual(100, command.ActionValues[0]);
            Assert.AreEqual(150, command.ActionValues[1]);
            Assert.AreEqual(2, command.ActionValues.Length);
        }
    }

    [TestClass()]
    public class DrawingSquares
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingSquareWithParameters()
        {
            //arrange
            string input = "square 125";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.square, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
        }

        [TestMethod()]
        public void ParseAction_DrawingSquareWithZeroParameters()
        {
            //arrange
            string input = "square";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.square, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
        }

        [TestMethod()]
        public void ParseInput_DrawingSquareWithParameters()
        {
            //arrange
            string input = "square 125";

            // act
            Command command = parser.ParseInput_SingleLine(input);

            // assert
            Assert.AreEqual(Action.square, command.ActionWord);
            Assert.AreNotEqual(Action.circle, command.ActionWord);
            Assert.AreNotEqual(Action.rectangle, command.ActionWord);
            Assert.AreEqual(125, command.ActionValues[0]);
            Assert.AreEqual(1, command.ActionValues.Length);
        }
    }

    [TestClass()]
    public class DrawingTriangles
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingTriangleWithParameters()
        {
            //arrange
            string input = "triangle 225";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.triangle, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
        }

        [TestMethod()]
        public void ParseAction_DrawingTriangleWithZeroParameters()
        {
            //arrange
            string input = "triangle";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.triangle, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
        }

        [TestMethod()]
        public void ParseInput_DrawingTriangleWithParameters()
        {
            //arrange
            string input = "triangle 225";

            // act
            Command command = parser.ParseInput_SingleLine(input);

            // assert
            Assert.AreEqual(Action.triangle, command.ActionWord);
            Assert.AreNotEqual(Action.rectangle, command.ActionWord);
            Assert.AreNotEqual(Action.square, command.ActionWord);
            Assert.AreEqual(225, command.ActionValues[0]);
            Assert.AreEqual(1, command.ActionValues.Length);
        }
    }

    [TestClass()]
    public class DrawingLines
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingLineWithParameters()
        {
            //arrange
            string input = "drawto 125 210";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.drawto, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
            Assert.AreNotEqual(Action.triangle, action);
        }

        [TestMethod()]
        public void ParseAction_DrawingLineWithNoParameters()
        {
            //arrange
            string input = "drawto";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.drawto, action);
            Assert.AreNotEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
            Assert.AreNotEqual(Action.triangle, action);
        }

        [TestMethod()]
        public void ParseInput_DrawingLineWithParameters()
        {
            //arrange
            string input = "drawto 125 210";

            // act
            Command command = parser.ParseInput_SingleLine(input);

            // assert
            Assert.AreEqual(Action.drawto, command.ActionWord);
            Assert.AreNotEqual(Action.circle, command.ActionWord);
            Assert.AreNotEqual(Action.rectangle, command.ActionWord);
            Assert.AreNotEqual(Action.square, command.ActionWord);
            Assert.AreNotEqual(Action.triangle, command.ActionWord);
            Assert.AreEqual(125, command.ActionValues[0]);
            Assert.AreEqual(210, command.ActionValues[1]);
            Assert.AreEqual(2, command.ActionValues.Length);
        }
    }

    [TestClass()]
    public class PartTwo
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseMultiline_DrawingRectangle_WithVariables()
        {
            // Creates a couple of variables and attempts to draw a rectangle with the variable values for dimensions.

            // arrange
            string input = "x = 10\ny = 25\nrectangle x y";

            // act
            List<Command> commands = parser.ParseInput_MultiLine(input);

            // assert
            Assert.AreEqual(3, commands.Count);
        }

        [TestMethod()]
        public void ParseMultiline_DrawingCircles_WithWhileLoop()
        {
            // Creates and starts a while loop to draw increasingly larger circles with the help of two counter variables.

            // arrange
            string input = "x = 0\n   size = 10\n   while x < 100\n   circle size\n   x = x + 10\n   size = size + 10\n   endwhile";

            // act
            List<Command> commands = parser.ParseInput_MultiLine(input);

            // assert
            Assert.AreEqual(7, commands.Count);
        }

        [TestMethod()]
        public void ParseMultiline_DrawingRectangles_WithForLoop()
        {
            // Creates and starts a for loop to draw increasingly smaller rectangles with the help of a couple of counter variables.

            // arrange
            string input = "x = 10\n size = 100\n for(x;x<10;x-1)\n rectangle size size\n size = size - 10\n endfor";

            // act
            List<Command> commands = parser.ParseInput_MultiLine(input);

            // assert
            Assert.AreEqual(6, commands.Count);
        }
    }
}
