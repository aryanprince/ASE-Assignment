using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Rectangle = ASE_Assignment.Rectangle;

namespace Unit_Tests
{

    [TestClass()]
    public class DrawingRectangles
    {
        private readonly Parser _parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingCircleWithZeroParameters()
        {
            // arrange
            string input = "rectangle";

            // act
            Action action = _parser.ParseAction_Command(input);

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.square, action);
            Assert.AreNotEqual(Action.circle, action);
        }

        [TestMethod()]
        public void ParseAction_DrawingCircleWithParameters()
        {
            // arrange
            string input = "rectangle 100 150";

            // act
            Action action = _parser.ParseAction_Command(input);

            // assert
            Assert.IsNotNull(action);
            Assert.AreEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.circle, action);
        }

        [TestMethod()]
        public void ParseInput_DrawingRectangleWithZeroParameters()
        {
            // arrange
            string input = "rectangle";

            // act
            Command command = _parser.ParseInput_SingleLine(input);

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
            // arrange
            string input = "rectangle 100 150";

            // act
            Command command = _parser.ParseInput_SingleLine(input);

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
            // arrange
            string input = "rEcTaNgLe 100 150";

            // act
            Command command = _parser.ParseInput_SingleLine(input);

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
        public void ParseInput_CreatingRectangleInstance()
        {
            // arrange
            string input = "rectangle 100 150";

            // act
            Command command = _parser.ParseInput_SingleLine(input);
            ShapeFactory shapeFactory = new ShapeFactory();
            Cursor cursor = new Cursor();
            Shape shape = shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor);

            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Rectangle)); // assert that shape is a rectangle
            Assert.IsNotInstanceOfType(shape, typeof(Circle));
            // checks that the values are set to default values as they are not specified in the input
            Assert.AreEqual(shape.DefaultFill, shape.Fill);
            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
            Assert.AreEqual(shape.DefaultPosition, shape.Position);
            // manually checking the values to check that they are set correctly
            Assert.AreEqual(false, shape.Fill);
            Assert.AreEqual(Color.Red, shape.PenColor);
            Assert.AreEqual(new Point(0, 0), shape.Position);
        }

        [TestMethod()]
        public void ParseInput_CreatingRectangleInstanceWithDifferentCase()
        {
            // arrange
            string input = "rEcTaNgLe 100 150";

            // act
            Command command = _parser.ParseInput_SingleLine(input);
            ShapeFactory shapeFactory = new ShapeFactory();
            Cursor cursor = new Cursor();
            Shape shape = shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor);

            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Rectangle)); // assert that shape is a rectangle
            Assert.IsNotInstanceOfType(shape, typeof(Circle));
            // checks that the values are set to default values as they are not specified in the input
            Assert.AreEqual(shape.DefaultFill, shape.Fill);
            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
            Assert.AreEqual(shape.DefaultPosition, shape.Position);
            // manually checking the values to check that they are set correctly
            Assert.AreEqual(false, shape.Fill);
            Assert.AreEqual(Color.Red, shape.PenColor);
            Assert.AreEqual(new Point(0, 0), shape.Position);
        }
    }

    [TestClass()]
    public class DrawingCircles
    {
        private readonly Parser _parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingCircleWithParameters()
        {
            // arrange
            string input = "circle 100 150";

            // act
            Action action = _parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
        }

        [TestMethod()]
        public void ParseAction_DrawingCircleWithZeroParameters()
        {
            // arrange
            string input = "circle";

            // act
            Action action = _parser.ParseAction_Command(input);

            // assert
            Assert.AreEqual(Action.circle, action);
            Assert.AreNotEqual(Action.rectangle, action);
        }

        [TestMethod()]
        public void ParseInput_DrawingCircleWithParameters()
        {
            // arrange
            string input = "circle 100 150";

            // act
            Command command = _parser.ParseInput_SingleLine(input);

            // assert
            Assert.AreEqual(Action.circle, command.ActionWord);
            Assert.AreEqual(100, command.ActionValues[0]);
            Assert.AreEqual(150, command.ActionValues[1]);
            Assert.AreEqual(2, command.ActionValues.Length);
        }

        [TestMethod()]
        public void ParseInput_DrawingCircleWithZeroParameters()
        {
            // arrange
            string input = "circle";

            // act
            Command command = _parser.ParseInput_SingleLine(input);

            // assert
            Assert.AreEqual(Action.circle, command.ActionWord);
            Assert.AreEqual(0, command.ActionValues.Length);
        }

        [TestMethod()]
        public void ParseInput_DrawingCircleWithDifferentCase()
        {
            // arrange
            string input = "cIrClE 100 150";

            // act
            Command command = _parser.ParseInput_SingleLine(input);

            // assert
            Assert.AreEqual(Action.circle, command.ActionWord);
            Assert.AreEqual(100, command.ActionValues[0]);
            Assert.AreEqual(150, command.ActionValues[1]);
            Assert.AreEqual(2, command.ActionValues.Length);
        }

        [TestMethod()]
        public void ParseInput_CreatingCircleInstance()
        {
            // arrange
            string input = "circle 100 150";

            // act
            Command command = _parser.ParseInput_SingleLine(input);
            ShapeFactory shapeFactory = new ShapeFactory();
            Cursor cursor = new Cursor();
            Shape shape = shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor);

            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Circle)); // assert that shape is a circle
            Assert.IsNotInstanceOfType(shape, typeof(Rectangle));
            // checks that the values are set to default values as they are not specified in the input
            Assert.AreEqual(shape.DefaultFill, shape.Fill);
            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
            Assert.AreEqual(shape.DefaultPosition, shape.Position);
            // manually checking the values to check that they are set correctly
            Assert.AreEqual(false, shape.Fill);
            Assert.AreEqual(Color.Red, shape.PenColor);
            Assert.AreEqual(new Point(0, 0), shape.Position);
        }

        [TestMethod()]
        public void ParseInput_CreatingCircleInstanceWithDifferentCase()
        {
            // arrange
            string input = "cIrClE 100 150";

            // act
            Command command = _parser.ParseInput_SingleLine(input);
            ShapeFactory shapeFactory = new ShapeFactory();
            Cursor cursor = new Cursor();
            Shape shape = shapeFactory.CreateShape(command, cursor.Position, cursor.Fill, cursor.PenColor);

            // assert
            Assert.IsNotNull(shape);
            Assert.IsInstanceOfType(shape, typeof(Circle)); // assert that shape is a circle
            Assert.IsNotInstanceOfType(shape, typeof(Rectangle));
            // checks that the values are set to default values as they are not specified in the input
            Assert.AreEqual(shape.DefaultFill, shape.Fill);
            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
            Assert.AreEqual(shape.DefaultPosition, shape.Position);
            // manually checking the values to check that they are set correctly
            Assert.AreEqual(false, shape.Fill);
            Assert.AreEqual(Color.Red, shape.PenColor);
            Assert.AreEqual(new Point(0, 0), shape.Position);
        }
    }

    [TestClass()]
    public class DrawingSquares
    {
        private readonly Parser _parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingSquareWithParameters()
        {
            //arrange
            string input = "square 125";

            // act
            Action action = _parser.ParseAction_Command(input);

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
            Action action = _parser.ParseAction_Command(input);

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
            Command command = _parser.ParseInput_SingleLine(input);

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
        private readonly Parser _parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingTriangleWithParameters()
        {
            //arrange
            string input = "triangle 225";

            // act
            Action action = _parser.ParseAction_Command(input);

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
            Action action = _parser.ParseAction_Command(input);

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
            Command command = _parser.ParseInput_SingleLine(input);

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
        private readonly Parser _parser = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingLineWithParameters()
        {
            //arrange
            string input = "drawto 125 210";

            // act
            Action action = _parser.ParseAction_Command(input);

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
            Action action = _parser.ParseAction_Command(input);

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
            Command command = _parser.ParseInput_SingleLine(input);

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
