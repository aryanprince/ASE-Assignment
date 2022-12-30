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

        //Write a function called Tokenizer 2 that iterates through every single character in the string and tokenizes it. If the next character is still a part of previous Token, then add it to the previous Token. If the next character is not a part of the previous Token, then create a new Token.
        public List<Token> Tokenize2(string input)
        {
            List<Token> tokens = new List<Token>();

            //Loop through each character in the input string
            for (int i = 0; i < input.Length; i++)
            {
                //Check if the character is a number
                if (int.TryParse(input[i].ToString(), out int number))
                {
                    //Check if the previous token is a number
                    if (tokens.Count > 0 && tokens[tokens.Count - 1].Type == TokenType.NUMBER)
                    {
                        //Add the number to the previous token
                        tokens[tokens.Count - 1].Value += number.ToString();
                    }
                    else
                    {
                        //Create a new token
                        tokens.Add(new Token(TokenType.NUMBER, number.ToString()));
                    }
                }
                //Check if the character is an identifier
                else if (char.IsLetter(input[i]))
                {
                    //Check if the previous token is an identifier
                    if (tokens.Count > 0 && tokens[tokens.Count - 1].Type == TokenType.IDENTIFIER)
                    {
                        //Add the identifier to the previous token
                        tokens[tokens.Count - 1].Value += input[i].ToString();
                    }
                    else
                    {
                        //Create a new token
                        tokens.Add(new Token(TokenType.IDENTIFIER, input[i].ToString()));
                    }
                }
                //Check if the character is an assignment operator
                else if (input[i] == '=')
                {
                    //Check if the previous token is an assignment operator
                    if (tokens.Count > 0 && tokens[tokens.Count - 1].Type == TokenType.ASSIGNMENT_OPERATOR)
                    {
                        //Add the assignment operator to the previous token
                        tokens[tokens.Count - 1].Value += input[i].ToString();
                    }
                    else
                    {
                        //Create a new token
                        tokens.Add(new Token(TokenType.ASSIGNMENT_OPERATOR, input[i].ToString()));
                    }
                }
                //Check if the character is an arithmetic operator
                else if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
                {
                    //Check if the previous token is an arithmetic operator
                    if (tokens.Count > 0 && tokens[tokens.Count - 1].Type == TokenType.ARITHMETIC_OPERATOR)
                    {
                        //Add the arithmetic operator to the previous token
                        tokens[tokens.Count - 1].Value += input[i].ToString();
                    }
                    else
                    {
                        //Create a new token
                        tokens.Add(new Token(TokenType.ARITHMETIC_OPERATOR, input[i].ToString()));
                    }
                }
                //If the character is not a number, identifier or assignment operator, throw an exception
                else
                {
                    throw new Exception("ERROR: Invalid input!");
                }
            }

            return tokens;
        }
    }
}
