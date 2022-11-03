using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASE_Assignment.Tests
{
    [TestClass()]
    public class DrawingCircles
    {
        Parser p = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingCircleWithParameters()
        {
            //arrange
            string input = "circle 100 150";

            // act
            Action action = p.ParseActionWord(input);

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
            Action action = p.ParseActionWord(input);

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
            Command command = p.ParseInput(input);
            int[] test = { 100, 150 };

            // assert
            Assert.AreEqual(Action.circle, command.ActionWord);
            Assert.AreEqual(100, command.ActionValues[0]);
            Assert.AreEqual(150, command.ActionValues[1]);
            Assert.AreEqual(2, command.ActionValues.Length);
        }
    }
    [TestClass()]
    public class DrawingRectangles
    {
        Parser p = new Parser();

        [TestMethod()]
        public void ParseAction_DrawingCircleWithParameters()
        {
            //arrange
            string input = "rectangle 100 150";

            // act
            Action action = p.ParseActionWord(input);

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
            Action action = p.ParseActionWord(input);

            // assert
            Assert.AreEqual(Action.rectangle, action);
            Assert.AreNotEqual(Action.circle, action);
        }

        [TestMethod()]
        public void ParseInput_DrawingRectangleWithParameters()
        {
            //arrange
            string input = "rectangle 100 150";

            // act
            Command command = p.ParseInput(input);

            // assert
            Assert.AreEqual(Action.rectangle, command.ActionWord);
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
                Command command = p.ParseInput(input);

                // assert
                Assert.AreEqual(Action.rectangle, command.ActionWord);
                Assert.AreEqual(100, command.ActionValues[0]);
                Assert.AreEqual(150, command.ActionValues[1]);
                Assert.AreEqual(2, command.ActionValues.Length);

                //arrange
                input = "fill";

                // act
                command = p.ParseInput(input);

                // assert
                Assert.AreEqual(Action.fill, command.ActionWord);
            }
        }
    }
}
