//using ASE_Assignment;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;

//namespace Unit_Tests
//{
//    [TestClass()]
//    [Ignore] // These tests are ignored for Part 1 submission but will be used for Part 2
//    public class PartTwoTestsForPartOneRequirements
//    {
//        Parser parser = new Parser();

//        [TestMethod()]
//        public void ParseMultiline_DrawingRectangle_WithVariables()
//        {
//            // Creates a couple of variables and attempts to draw a rectangle with the variable values for dimensions.

//            // arrange
//            string input = "x = 10\ny = 25\nrectangle x y";

//            // act
//            List<CommandShape> commands = parser.ParseInput_MultiLine(input);

//            // assert
//            Assert.AreEqual(3, commands.Count);
//        }

//        [TestMethod()]
//        public void ParseMultiline_DrawingTwoTrianglesInsideRectangle_WithMethod()
//        {
//            // Creates a method to draw 2 triangles, then draws a rectangle and calls the method after it to draw the triangles inside the rectangle.

//            // arrange
//            string input = "method twoTriangles\ntriangle 50\ntriangle 75\nendmethod\nrectangle 200 250\ntwoTriangles";

//            // act
//            List<CommandShape> commands = parser.ParseInput_MultiLine(input);

//            // assert
//            Assert.AreEqual(6, commands.Count);
//        }

//        [TestMethod()]
//        public void ParseMultiline_DrawingCircles_WithWhileLoop()
//        {
//            // Creates and starts a while loop to draw increasingly larger circles with the help of two counter variables.

//            // arrange
//            string input = "x = 0\n   size = 10\n   while x < 100\n   circle size\n   x = x + 10\n   size = size + 10\n   endwhile";

//            // act
//            List<CommandShape> commands = parser.ParseInput_MultiLine(input);

//            // assert
//            Assert.AreEqual(7, commands.Count);
//        }

//        [TestMethod()]
//        public void ParseMultiline_DrawingRectangles_WithForLoop()
//        {
//            // Creates and starts a for loop to draw increasingly smaller rectangles with the help of a couple of counter variables.

//            // arrange
//            string input = "x = 10\n size = 100\n for(x;x<10;x-1)\n rectangle size size\n size = size - 10\n endfor";

//            // act
//            List<CommandShape> commands = parser.ParseInput_MultiLine(input);

//            // assert
//            Assert.AreEqual(6, commands.Count);
//        }
//    }
//}
