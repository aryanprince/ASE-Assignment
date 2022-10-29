using System.Collections.Generic;

namespace ASE_Assignment
{
    public class Command
    {
        internal ValidCommandsEnum Action { get; set; }
        internal IEnumerable<int> Coordinates { get; set; }

        public Command(ValidCommandsEnum action, IEnumerable<int> coordinates)
        {
            Action = action;
            Coordinates = coordinates;
        }
    }
}
