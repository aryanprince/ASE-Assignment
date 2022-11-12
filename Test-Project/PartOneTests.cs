﻿using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Tests
{

    [TestClass()]
    public class DrawingRectangles
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingCircleWithZeroParameters()
        {
            //arrange
            string input = "rectangle";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
            Assert.AreNotEqual(Action.circle, action);
        }

        [TestMethod()]
        public void ParseAction_DrawingCircleWithParameters()
        {
            //arrange
            string input = "rectangle 100 150";

            // act
            Action action = parser.ParseAction_Command(input);

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.circle, action);
        }

        [TestMethod()]
        public void ParseInput_DrawingRectangleWithZeroParameters()
        {
            //arrange
            string input = "rectangle";

            // act
            Command command = parser.ParseInput_SingleLine(input);

            // assert
            Assert.IsNotNull(command);
            Assert.AreEqual(Action.rectangle, command.ActionWord);
            Assert.AreNotEqual(Action.circle, command.ActionWord);
            Assert.AreNotEqual(Action.square, command.ActionWord);
            Assert.AreEqual(0, command.ActionValues.Length);
        }

        [TestMethod()]
        public void ParseInput_DrawingRectangleWithParameters()
        {
            //arrange
            string input = "rectangle 100 150";

            // act
            Command command = parser.ParseInput_SingleLine(input);

            // assert
            Assert.IsNotNull(command);
            Assert.AreEqual(Action.rectangle, command.ActionWord);
            Assert.AreNotEqual(Action.circle, command.ActionWord);
            Assert.AreNotEqual(Action.square, command.ActionWord);
            Assert.AreEqual(100, command.ActionValues[0]);
            Assert.AreEqual(150, command.ActionValues[1]);
            Assert.AreEqual(2, command.ActionValues.Length);
        }

        [TestMethod()]
        public void ParseInput_DrawingRectangleWithDifferentCase()
        {
            //arrange
            string input = "rEcTaNgLe 100 150";

            // act
            Command command = parser.ParseInput_SingleLine(input);

            // assert
            Assert.IsNotNull(command);
            Assert.AreEqual(Action.rectangle, command.ActionWord);
            Assert.AreNotEqual(Action.circle, command.ActionWord);
            Assert.AreNotEqual(Action.square, command.ActionWord);
            Assert.AreEqual(100, command.ActionValues[0]);
            Assert.AreEqual(150, command.ActionValues[1]);
            Assert.AreEqual(2, command.ActionValues.Length);
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
}
