//using ASE_Assignment;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Drawing;
//using Action = ASE_Assignment.Action;
//using Rectangle = ASE_Assignment.Rectangle;

//namespace Unit_Tests
//{

//    [TestClass()]
//    public class DrawingRectangles
//    {
//        private readonly Parser _parser = new Parser();

//        [TestMethod()]
//        public void ParseAction_DrawingRectangle_WithZeroParameters()
//        {
//            // arrange
//            string input = "rectangle";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.rectangle, action); // Assert that the action is a rectangle
//            Assert.AreNotEqual(Action.square, action); // Assert that the action is not a square
//            Assert.AreNotEqual(Action.circle, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingRectangle_WithParameters()
//        {
//            // arrange
//            string input = "rectangle 100 150";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.rectangle, action);
//            Assert.AreNotEqual(Action.circle, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingRectangle_WithDifferentCase()
//        {
//            // arrange
//            string input = "RECTANGLE 100 150";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.rectangle, action);
//            Assert.AreNotEqual(Action.circle, action);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingRectangle_WithParameters()
//        {
//            // arrange
//            string input = "rectangle 100 150";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.rectangle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.circle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.square, commandShape.ActionWord);
//            Assert.AreEqual(100, commandShape.ActionValues[0]);
//            Assert.AreEqual(150, commandShape.ActionValues[1]);
//            Assert.AreEqual(2, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingRectangle_WithDifferentCase()
//        {
//            // arrange
//            string input = "rEcTaNgLe 100 150";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.rectangle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.circle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.square, commandShape.ActionWord);
//            Assert.AreEqual(100, commandShape.ActionValues[0]);
//            Assert.AreEqual(150, commandShape.ActionValues[1]);
//            Assert.AreEqual(2, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingRectangleInstance_WithParameters()
//        {
//            // arrange
//            string input = "rectangle 100 150";

//            // act
//            // Creating an instance of all the classes that are needed to create a rectangle
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates the shape

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Rectangle)); // assert that shape is a rectangle
//            Assert.IsNotInstanceOfType(shape, typeof(Circle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingRectangleInstance_WithDifferentCase()
//        {
//            // arrange
//            string input = "rEcTaNgLe 100 150";

//            // act
//            // Creating an instance of all the classes that are needed to create a rectangle
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates the shape

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Rectangle)); // assert that shape is a rectangle
//            Assert.IsNotInstanceOfType(shape, typeof(Circle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }
//    }

//    [TestClass()]
//    public class DrawingCircles
//    {
//        private readonly Parser _parser = new Parser();

//        [TestMethod()]
//        public void ParseAction_DrawingCircle_WithParameters()
//        {
//            // arrange
//            string input = "circle 100 150";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingCircle_WithZeroParameters()
//        {
//            // arrange
//            string input = "circle";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingCircle_WithDifferentCase()
//        {
//            // arrange
//            string input = "CiRcLe";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingCircle_WithParameters()
//        {
//            // arrange
//            string input = "circle 100 150";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.circle, commandShape.ActionWord);
//            Assert.AreEqual(100, commandShape.ActionValues[0]);
//            Assert.AreEqual(150, commandShape.ActionValues[1]);
//            Assert.AreEqual(2, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingCircle_WithDifferentCase()
//        {
//            // arrange
//            string input = "cIrClE 100 150";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.circle, commandShape.ActionWord);
//            Assert.AreEqual(100, commandShape.ActionValues[0]);
//            Assert.AreEqual(150, commandShape.ActionValues[1]);
//            Assert.AreEqual(2, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingCircleInstance_WithParameters()
//        {
//            // arrange
//            string input = "circle 100 150";

//            // act
//            // Creating an instance of all the classes that are needed to create a circle
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates a circle using the factory

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Circle)); // assert that shape is a circle
//            Assert.IsNotInstanceOfType(shape, typeof(Rectangle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingCircleInstance_WithDifferentCase()
//        {
//            // arrange
//            string input = "cIrClE 100 150";

//            // act
//            // Creating an instance of all the classes that are needed to create a circle
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates a circle using the factory

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Circle)); // assert that shape is a circle
//            Assert.IsNotInstanceOfType(shape, typeof(Rectangle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }
//    }

//    [TestClass()]
//    public class DrawingSquares
//    {
//        private readonly Parser _parser = new Parser();

//        [TestMethod()]
//        public void ParseAction_DrawingSquare_WithParameters()
//        {
//            //arrange
//            string input = "square 125";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.square, action);
//            Assert.AreNotEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingSquare_WithZeroParameters()
//        {
//            //arrange
//            string input = "square";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.square, action);
//            Assert.AreNotEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingSquare_WithDifferentCase()
//        {
//            //arrange
//            string input = "sQuArE";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.square, action);
//            Assert.AreNotEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingSquare_WithParameters()
//        {
//            //arrange
//            string input = "square 125";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.square, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.circle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.rectangle, commandShape.ActionWord);
//            Assert.AreEqual(125, commandShape.ActionValues[0]);
//            Assert.AreEqual(1, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingSquare_WithDifferentCase()
//        {
//            //arrange
//            string input = "sQuArE 125";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.square, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.circle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.rectangle, commandShape.ActionWord);
//            Assert.AreEqual(125, commandShape.ActionValues[0]);
//            Assert.AreEqual(1, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingSquareInstance_WithParameters()
//        {
//            //arrange
//            string input = "square 125";

//            // act
//            // Creating an instance of all the classes that are needed to create a square
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates a square using the factory

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Square)); // assert that shape is a square
//            Assert.IsInstanceOfType(shape, typeof(Rectangle)); // assert that shape is also a rectangle since square is a rectangle
//            Assert.IsNotInstanceOfType(shape, typeof(Circle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingSquareInstance_WithDifferentCase()
//        {
//            //arrange
//            string input = "sQuArE 125";

//            // act
//            // Creating an instance of all the classes that are needed to create a square
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates a square using the factory

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Square)); // assert that shape is a square
//            Assert.IsInstanceOfType(shape, typeof(Rectangle)); // assert that shape is also a rectangle since square is a rectangle
//            Assert.IsNotInstanceOfType(shape, typeof(Circle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }
//    }

//    [TestClass()]
//    public class DrawingTriangles
//    {
//        private readonly Parser _parser = new Parser();

//        [TestMethod()]
//        public void ParseAction_DrawingTriangle_WithParameters()
//        {
//            //arrange
//            string input = "triangle 225";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.triangle, action);
//            Assert.AreNotEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//            Assert.AreNotEqual(Action.square, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingTriangle_WithZeroParameters()
//        {
//            //arrange
//            string input = "triangle";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.triangle, action);
//            Assert.AreNotEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//            Assert.AreNotEqual(Action.square, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingTriangle_WithDifferentCase()
//        {
//            //arrange
//            string input = "tRiAnGlE";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.triangle, action);
//            Assert.AreNotEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//            Assert.AreNotEqual(Action.square, action);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingTriangle_WithParameters()
//        {
//            //arrange
//            string input = "triangle 225";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.triangle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.rectangle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.square, commandShape.ActionWord);
//            Assert.AreEqual(225, commandShape.ActionValues[0]);
//            Assert.AreEqual(1, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingTriangle_WithDifferentCase()
//        {
//            //arrange
//            string input = "tRiAnGlE 225";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.triangle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.rectangle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.square, commandShape.ActionWord);
//            Assert.AreEqual(225, commandShape.ActionValues[0]);
//            Assert.AreEqual(1, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingTriangleInstance_WithParameters()
//        {
//            //arrange
//            string input = "triangle 225";

//            // act
//            // Creating an instance of all the classes that are needed to create a triangle
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates a triangle using the factory

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Triangle));
//            Assert.IsNotInstanceOfType(shape, typeof(Square));
//            Assert.IsNotInstanceOfType(shape, typeof(Rectangle));
//            Assert.IsNotInstanceOfType(shape, typeof(Circle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingTriangleInstance_WithDifferentCase()
//        {
//            //arrange
//            string input = "tRiAnGlE 225";

//            // act
//            // Creating an instance of all the classes that are needed to create a triangle
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates a triangle using the factory

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Triangle));
//            Assert.IsNotInstanceOfType(shape, typeof(Square));
//            Assert.IsNotInstanceOfType(shape, typeof(Rectangle));
//            Assert.IsNotInstanceOfType(shape, typeof(Circle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }
//    }

//    [TestClass()]
//    public class DrawingLines
//    {
//        private readonly Parser _parser = new Parser();

//        [TestMethod()]
//        public void ParseAction_DrawingLine_WithParameters()
//        {
//            //arrange
//            string input = "drawto 125 210";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.drawto, action);
//            Assert.AreNotEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//            Assert.AreNotEqual(Action.square, action);
//            Assert.AreNotEqual(Action.triangle, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingLine_WithNoParameters()
//        {
//            //arrange
//            string input = "drawto";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.drawto, action);
//            Assert.AreNotEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//            Assert.AreNotEqual(Action.square, action);
//            Assert.AreNotEqual(Action.triangle, action);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingLine_WithDifferentCase()
//        {
//            //arrange
//            string input = "dRaWtO 125 210";

//            // act
//            Action action = _parser.ParseAction_Command(input); // Parse the input and get the action

//            // assert
//            Assert.IsNotNull(action);
//            Assert.AreEqual(Action.drawto, action);
//            Assert.AreNotEqual(Action.circle, action);
//            Assert.AreNotEqual(Action.rectangle, action);
//            Assert.AreNotEqual(Action.square, action);
//            Assert.AreNotEqual(Action.triangle, action);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingLine_WithParameters()
//        {
//            //arrange
//            string input = "drawto 125 210";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.drawto, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.circle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.rectangle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.square, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.triangle, commandShape.ActionWord);
//            Assert.AreEqual(125, commandShape.ActionValues[0]);
//            Assert.AreEqual(210, commandShape.ActionValues[1]);
//            Assert.AreEqual(2, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_DrawingLine_WithDifferentCase()
//        {
//            //arrange
//            string input = "dRaWtO 125 210";

//            // act
//            CommandShape commandShape = _parser.ParseSingleLine(input); // Parse the input and get the command

//            // assert
//            Assert.IsNotNull(commandShape);
//            Assert.AreEqual(Action.drawto, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.circle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.rectangle, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.square, commandShape.ActionWord);
//            Assert.AreNotEqual(Action.triangle, commandShape.ActionWord);
//            Assert.AreEqual(125, commandShape.ActionValues[0]);
//            Assert.AreEqual(210, commandShape.ActionValues[1]);
//            Assert.AreEqual(2, commandShape.ActionValues.Length);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingLineInstance_WithParameters()
//        {
//            //arrange
//            string input = "drawto 125 210";

//            // act
//            // Creating an instance of all the classes that are needed to create a line
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates a line using the factory

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Line));
//            Assert.IsNotInstanceOfType(shape, typeof(Square));
//            Assert.IsNotInstanceOfType(shape, typeof(Rectangle));
//            Assert.IsNotInstanceOfType(shape, typeof(Circle));
//            Assert.IsNotInstanceOfType(shape, typeof(Triangle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }

//        [TestMethod()]
//        public void ParseInput_CreatingLineInstance_WithDifferentCase()
//        {
//            //arrange
//            string input = "dRaWtO 125 210";

//            // act
//            // Creating an instance of all the classes that are needed to create a line
//            CommandShape commandShape = _parser.ParseSingleLine(input);
//            ShapeFactory shapeFactory = new ShapeFactory();
//            Cursor cursor = new Cursor();
//            Shape shape = shapeFactory.CreateShape(commandShape, cursor.Position, cursor.Fill, cursor.PenColor); // Creates a line using the factory

//            // assert
//            Assert.IsNotNull(shape);
//            Assert.IsInstanceOfType(shape, typeof(Line));
//            Assert.IsNotInstanceOfType(shape, typeof(Square));
//            Assert.IsNotInstanceOfType(shape, typeof(Rectangle));
//            Assert.IsNotInstanceOfType(shape, typeof(Circle));
//            Assert.IsNotInstanceOfType(shape, typeof(Triangle));
//            // checks that the values are set to default values as they are not specified in the input
//            Assert.AreEqual(shape.DefaultFill, shape.Fill);
//            Assert.AreEqual(shape.DefaultPenColor, shape.PenColor);
//            Assert.AreEqual(shape.DefaultPosition, shape.Position);
//            // manually checking the values to check that they are set correctly
//            Assert.AreEqual(false, shape.Fill);
//            Assert.AreEqual(Color.Red, shape.PenColor);
//            Assert.AreEqual(new Point(0, 0), shape.Position);
//        }
//    }
//}
