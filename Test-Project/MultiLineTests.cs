using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Unit_Tests
{
    [TestClass]
    public class MultiLineTests
    {
        private readonly Parser _parser = new Parser();

        [TestMethod]
        public void ParseInput_MultiLine_Normal()
        {
            //arrange
            string input = "rectangle 100 150\nmove 50 80\ncircle 35";

            // act
            List<Command> commands = _parser.ParseInput_MultiLine(input);

            //assert
            // Common asserts for all commands
            Assert.AreEqual(3, commands.Count);
            // First line of commands
            Assert.IsNotNull(commands[0]);
            Assert.AreEqual(Action.rectangle, commands[0].ActionWord);
            Assert.AreNotEqual(Action.circle, commands[0].ActionWord);
            Assert.AreNotEqual(Action.square, commands[0].ActionWord);
            Assert.AreEqual(100, commands[0].ActionValues[0]);
            Assert.AreEqual(150, commands[0].ActionValues[1]);
            Assert.AreEqual(2, commands[0].ActionValues.Length);

            // Second line of commands
            Assert.IsNotNull(commands[1]);
            Assert.AreEqual(Action.move, commands[1].ActionWord);
            Assert.AreNotEqual(Action.circle, commands[1].ActionWord);
            Assert.AreNotEqual(Action.square, commands[1].ActionWord);
            Assert.AreEqual(50, commands[1].ActionValues[0]);
            Assert.AreEqual(80, commands[1].ActionValues[1]);
            Assert.AreEqual(2, commands[1].ActionValues.Length);

            // Third line of commands
            Assert.IsNotNull(commands[2]);
            Assert.AreEqual(Action.circle, commands[2].ActionWord);
            Assert.AreNotEqual(Action.move, commands[2].ActionWord);
            Assert.AreNotEqual(Action.square, commands[2].ActionWord);
            Assert.AreEqual(35, commands[2].ActionValues[0]);
            Assert.AreEqual(1, commands[2].ActionValues.Length);
        }
    }
}
