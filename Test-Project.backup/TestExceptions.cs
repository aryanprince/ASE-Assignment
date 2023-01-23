﻿using ASE_Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Tests
{
    [TestClass()]
    public class ExceptionTests
    {
        private readonly Parser _parser = new Parser();

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Input cannot be null")]
        public void ParseInput_InvalidCommand_EmptyInput()
        {
            //arrange
            string input = "";

            // act
            _parser.Parse(input, new Dictionary<string, int>()); // Parse the input and get the command
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseInput_InvalidCommand()
        {
            //arrange
            string input = "invalid";

            // act
            _parser.Parse(input, new Dictionary<string, int>()); // Parse the input and get the command
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseInput_InvalidCommand_WithParameters()
        {
            //arrange
            string input = "invalid 125 210";

            // act
            _parser.Parse(input, new Dictionary<string, int>()); // Parse the input and get the command
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseInput_InvalidCommand_WithNonIntegerParameters()
        {
            //arrange
            string input = "circle 12x";

            // act
            _parser.Parse(input, new Dictionary<string, int>()); // Parse the input and get the command
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseInput_InvalidCommand_WithTooManyParameters()
        {
            //arrange
            string input = "circle 125 210 125";

            // act
            _parser.Parse(input, new Dictionary<string, int>()); // Parse the input and get the command
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseInput_InvalidCommand_WithTooFewParameters()
        {
            //arrange
            string input = "circle";

            // act
            _parser.Parse(input, new Dictionary<string, int>()); // Parse the input and get the command
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseInput_InvalidCommand_WithNegativeParameters()
        {
            //arrange
            string input = "circle -125";

            // act
            _parser.Parse(input, new Dictionary<string, int>()); // Parse the input and get the command
        }
    }
}
