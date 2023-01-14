using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Unit_Tests
{
    [TestClass()]
    public class PartTwoTests
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
        }

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
            Assert.AreEqual(Action.endif, commands[3].ActionWord);
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
            Assert.AreEqual(Action.endif, commands[3].ActionWord);
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
            Assert.AreEqual(Action.endif, commands[4].ActionWord);
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
}
