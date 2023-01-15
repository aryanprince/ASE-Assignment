﻿namespace ASE_Assignment
{
    /// <summary>
    /// A class that implements the <see cref="Command" /> parent class and is used to store information such as loop count from a loop command.
    /// </summary>
    /// <seealso cref="Command" />
    public class CommandWhile : Command
    {
        public int LoopCount { get; set; }

        /// <summary>
        /// Constructor used to create a new instance of the <see cref="CommandWhile"/> class.
        /// </summary>
        /// <param name="actionWord">The action word.</param>
        /// <param name="loopCount">The loop count.</param>
        public CommandWhile(Action actionWord, int loopCount)
        {
            ActionWord = actionWord;
            LoopCount = loopCount;
        }
    }
}