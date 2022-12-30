using System;
using System.Collections.Generic;
using System.Linq;

namespace ASE_Assignment
{
    public class Tokenizer
    {
        //Create a tokenizer that tokenizes a string like "x = 25" into my TokenType enums
        public List<Token> Tokenize(string input)
        {
            List<Token> tokens = new List<Token>();

            //Split the input string into an array of strings, separated by spaces
            string[] inputSplitBySpaces = input.ToLower().Split(' ');

            //Loop through each word in the input string
            foreach (string word in inputSplitBySpaces)
            {
                //Check if the word is a number
                if (int.TryParse(word, out int number))
                {
                    tokens.Add(new Token(TokenType.NUMBER, number));
                }
                //Check if the word is an identifier
                else if (word.All(char.IsLetter))
                {
                    tokens.Add(new Token(TokenType.IDENTIFIER, word));
                }
                //Check if the word is an assignment operator
                else if (word == "=")
                {
                    tokens.Add(new Token(TokenType.ASSIGNMENT_OPERATOR, word));
                }
                //If the word is not a number, identifier or assignment operator, throw an exception
                else
                {
                    throw new Exception("ERROR: Invalid input!");
                }
            }

            return tokens;
        }
    }
}
