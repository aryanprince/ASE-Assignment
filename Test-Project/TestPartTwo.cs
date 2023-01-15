using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using Action = ASE_Assignment.Action;

namespace Unit_Tests
{
    [TestClass()]
    public class MultilineTest
    {
        [TestMethod()]
        public void Parse_MultilineInput_ReturnsCorrectShapes()
        {
            // Arrange
            string input = "rectangle 100 150\nmove 50 80\ncircle 35\nsquare 75";
            Parser parser = new Parser();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // Act
            List<Command> commands = parser.Parse(input, dictionary);

            // Assert
            Assert.AreEqual(4, commands.Count);
            Assert.IsInstanceOfType(commands, typeof(List<Command>));

            // First line of commands
            Assert.IsNotNull(commands[0]);
            Assert.IsInstanceOfType(commands[0], typeof(CommandShapeNum));
            Assert.AreEqual(Action.rectangle, commands[0].ActionWord);
            Assert.AreNotEqual(Action.circle, commands[0].ActionWord);
            Assert.AreNotEqual(Action.square, commands[0].ActionWord);

            // Second line of commands
            Assert.IsNotNull(commands[1]);
            Assert.IsInstanceOfType(commands[1], typeof(CommandShapeNum));
            Assert.AreEqual(Action.move, commands[1].ActionWord);
            Assert.AreNotEqual(Action.circle, commands[1].ActionWord);
            Assert.AreNotEqual(Action.square, commands[1].ActionWord);

            // Third line of commands
            Assert.IsNotNull(commands[2]);
            Assert.IsInstanceOfType(commands[2], typeof(CommandShapeNum));
            Assert.AreEqual(Action.circle, commands[2].ActionWord);
            Assert.AreNotEqual(Action.move, commands[2].ActionWord);
            Assert.AreNotEqual(Action.square, commands[2].ActionWord);

            // Fourth line of commands
            Assert.IsNotNull(commands[3]);
            Assert.IsInstanceOfType(commands[3], typeof(CommandShapeNum));
            Assert.AreEqual(Action.square, commands[3].ActionWord);
            Assert.AreNotEqual(Action.move, commands[3].ActionWord);
            Assert.AreNotEqual(Action.circle, commands[3].ActionWord);
        }
    }

    [TestClass()]
    public class VariableDeclarationTest
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void Parse_VariableDeclaration_SingleVariableOnly()
        {
            // ARRANGE
            string input = "var radius = 50\r\ncircle radius";
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // ACT
            List<Command> commands = parser.Parse(input, dictionary);

            // ASSERT
            Assert.AreEqual(2, commands.Count);
            Assert.AreEqual(Action.var, commands[0].ActionWord);
            Assert.AreEqual(Action.circle, commands[1].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(CommandVariable));
            Assert.IsInstanceOfType(commands[1], typeof(CommandShapeNum));
            // Checking values in the dictionary
            Assert.AreEqual(50, dictionary["radius"]);
            // Checking if the variable is overwritten
            Assert.AreEqual(1, dictionary.Count);
        }

        [TestMethod()]
        public void Parse_VariableDeclaration_MultipleVariables()
        {
            // ARRANGE
            string input = "var x = 50\r\ntriangle x\r\nvar y = 125\r\nvar x = x + 20\r\nrectangle x y";
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // ACT
            List<Command> commands = parser.Parse(input, dictionary);

            // ASSERT
            Assert.AreEqual(5, commands.Count);
            Assert.AreEqual(Action.var, commands[0].ActionWord);
            Assert.AreEqual(Action.triangle, commands[1].ActionWord);
            Assert.AreEqual(Action.var, commands[2].ActionWord);
            Assert.AreEqual(Action.var, commands[3].ActionWord);
            Assert.AreEqual(Action.rectangle, commands[4].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(CommandVariable));
            Assert.IsInstanceOfType(commands[1], typeof(CommandShapeNum));
            Assert.IsInstanceOfType(commands[2], typeof(CommandVariable));
            Assert.IsInstanceOfType(commands[3], typeof(CommandVariable));
            Assert.IsInstanceOfType(commands[4], typeof(CommandShapeNum));
            // Checking values in the dictionary
            Assert.AreEqual(70, dictionary["x"]);
            Assert.AreEqual(125, dictionary["y"]);
            // Checking if the variable is overwritten
            Assert.AreEqual(2, dictionary.Count);
        }
    }

    [TestClass()]
    public class IfStatementsTest
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void Parse_IfStatements_ReturnsTrue()
        {
            // ARRANGE
            string input = "var x = 50\r\nif x > 25\r\ntriangle x\r\nendif";

            // ACT
            List<Command> commands = parser.Parse(input, new Dictionary<string, int>());

            // ASSERT
            Assert.AreEqual(4, commands.Count);
            Assert.AreEqual(Action.var, commands[0].ActionWord);
            Assert.AreEqual(Action.ifstatement, commands[1].ActionWord);
            Assert.AreEqual(Action.triangle, commands[2].ActionWord);
            Assert.AreEqual(Action.end, commands[3].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(CommandVariable));
            Assert.IsInstanceOfType(commands[1], typeof(CommandIfStatements));
            Assert.IsInstanceOfType(commands[2], typeof(CommandShapeNum));
            Assert.IsInstanceOfType(commands[3], typeof(CommandEndKeyword));
            // Check if the if statement is correct
            Assert.AreEqual(true, ((CommandIfStatements)commands[1]).IfState);
            Assert.AreEqual(1, ((CommandIfStatements)commands[1]).StartIndex);
            Assert.AreEqual(3, ((CommandIfStatements)commands[1]).EndIndex);
        }

        [TestMethod()]
        public void Parse_IfStatements_ReturnsFalse()
        {
            // ARRANGE
            string input = "var y = 100\r\nif y < 25\r\nsquare y\r\nendif";

            // ACT
            List<Command> commands = parser.Parse(input, new Dictionary<string, int>());

            // ASSERT
            Assert.AreEqual(4, commands.Count);
            Assert.AreEqual(Action.var, commands[0].ActionWord);
            Assert.AreEqual(Action.ifstatement, commands[1].ActionWord);
            Assert.AreEqual(Action.square, commands[2].ActionWord);
            Assert.AreEqual(Action.end, commands[3].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(CommandVariable));
            Assert.IsInstanceOfType(commands[1], typeof(CommandIfStatements));
            Assert.IsInstanceOfType(commands[2], typeof(CommandShapeNum));
            Assert.IsInstanceOfType(commands[3], typeof(CommandEndKeyword));
            // Check if the if statement is correct
            Assert.AreEqual(false, ((CommandIfStatements)commands[1]).IfState);
            Assert.AreEqual(1, ((CommandIfStatements)commands[1]).StartIndex);
            Assert.AreEqual(3, ((CommandIfStatements)commands[1]).EndIndex);
        }
    }

    [TestClass()]
    public class WhileLoopsTest
    {
        Parser parser = new Parser();

        [TestMethod()]
        public void Parse_WhileLoop_ReturnsTrue()
        {
            // ARRANGE
            string input = "var x = 50\r\nwhile 10\r\nvar x = x + 10\r\ntriangle x\r\nendwhile";

            // ACT
            List<Command> commands = parser.Parse(input, new Dictionary<string, int>());

            // ASSERT
            Assert.AreEqual(5, commands.Count);
            Assert.AreEqual(Action.var, commands[0].ActionWord);
            Assert.AreEqual(Action.whileloop, commands[1].ActionWord);
            Assert.AreEqual(Action.var, commands[2].ActionWord);
            Assert.AreEqual(Action.triangle, commands[3].ActionWord);
            Assert.AreEqual(Action.end, commands[4].ActionWord);
            // Checking types of commands
            Assert.IsInstanceOfType(commands[0], typeof(CommandVariable));
            Assert.IsInstanceOfType(commands[1], typeof(CommandWhile));
            Assert.IsInstanceOfType(commands[2], typeof(CommandVariable));
            Assert.IsInstanceOfType(commands[3], typeof(CommandShapeNum));
            Assert.IsInstanceOfType(commands[4], typeof(CommandEndKeyword));
            // Check if the while loop is correct
            Assert.AreEqual(10, ((CommandWhile)commands[1]).LoopCount);
        }
    }

    [TestClass()]
    public class ShapeFactoryTest
    {
        ShapeFactory shapeFactory = ShapeFactory.Instance;

        [TestMethod()]
        public void CreateShape_Triangle_ReturnsShape()
        {
            // ARRANGE
            int x = 50;
            int y = 100;
            int length = 250;
            bool fill = true;
            Color color = Color.Red;

            // ACT
            Shape shape = shapeFactory.CreateShape(new CommandShapeNum(Action.triangle, new[] { length }), new Point(x, y), fill, color);

            // ASSERT
            Assert.IsInstanceOfType(shape, typeof(Triangle));
            Assert.AreEqual(x, shape.Position.X);
            Assert.AreEqual(y, shape.Position.Y);
            Assert.AreEqual(length, ((Triangle)shape).Length);
            Assert.AreEqual(fill, shape.Fill);
            Assert.AreEqual(color, shape.PenColor);
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShape_InvalidShape_ThrowsException()
        {
            // ARRANGE
            int x = 50;
            int y = 100;
            int length = 250;
            bool fill = true;
            Color color = Color.Red;

            // ACT
            Shape shape = shapeFactory.CreateShape(new CommandShapeNum(Action.none, new[] { 0 }), new Point(x, y), fill, color);

            // ASSERT
            Assert.IsInstanceOfType(shape, typeof(Triangle));
            Assert.AreEqual(x, shape.Position.X);
            Assert.AreEqual(y, shape.Position.Y);
            Assert.AreEqual(length, ((Triangle)shape).Length);
            Assert.AreEqual(fill, shape.Fill);
            Assert.AreEqual(color, shape.PenColor);
        }
    }
}
