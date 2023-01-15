namespace ASE_Assignment
{
    /// <summary>
    /// A base class for all command types that stores only the command type as an Enum.
    /// </summary>
    public class Command
    {
        public Action ActionWord { get; set; }
    }
}
