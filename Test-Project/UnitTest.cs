//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace ASE_Assignment.Tests
//{
//    [TestClass()]
//    public class DrawingCircles
//    {
//        Parser p = new Parser();

//        [TestMethod()]
//        public void ParseAction_DrawingCircleWithParameters()
//        {
//            //arrange
//            string input = "circle 100 150";

//            // act
//            ValidCommandsEnum result = p.ParseInput(input);

//            // assert
//            Assert.AreEqual(ValidCommandsEnum.circle, result);
//            Assert.AreNotEqual(ValidCommandsEnum.rectangle, result);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingCircleWithZeroParameters()
//        {
//            //arrange
//            string input = "circle";

//            // act
//            ValidCommandsEnum result = p.ParseInput(input);

//            // assert
//            Assert.AreEqual(ValidCommandsEnum.circle, result);
//            Assert.AreNotEqual(ValidCommandsEnum.rectangle, result);
//        }
//    }
//    [TestClass()]
//    public class DrawingRectangles
//    {
//        Parser p = new Parser();

//        [TestMethod()]
//        public void ParseAction_DrawingCircleWithParameters()
//        {
//            //arrange
//            string input = "rectangle 100 150";

//            // act
//            Parser p = new Parser();
//            ValidCommandsEnum result = p.ParseInput(input);

//            // assert
//            Assert.AreEqual(ValidCommandsEnum.rectangle, result);
//            Assert.AreNotEqual(ValidCommandsEnum.circle, result);
//        }

//        [TestMethod()]
//        public void ParseAction_DrawingCircleWithZeroParameters()
//        {
//            //arrange
//            string input = "rectangle";

//            // act
//            Parser p = new Parser();
//            ValidCommandsEnum result = p.ParseInput(input);

//            // assert
//            Assert.AreEqual(ValidCommandsEnum.rectangle, result);
//            Assert.AreNotEqual(ValidCommandsEnum.circle, result);
//        }
//    }
//}
