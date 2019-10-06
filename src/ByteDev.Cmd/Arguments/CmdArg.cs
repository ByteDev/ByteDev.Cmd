namespace ByteDev.Cmd.Arguments
{
    /// <summary>
    /// Represents an input command line argument.
    /// </summary>
    public class CmdArg
    {
        /// <summary>
        /// Short name for the argument.
        /// </summary>
        public char ShortName { get; internal set; }

        /// <summary>
        /// Long name for the argument.
        /// </summary>
        public string LongName { get; internal set; }        

        /// <summary>
        /// Argument value.
        /// </summary>
        public string Value { get; internal set; }

        /// <summary>
        /// Description of the argument.
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// Whether the argument has a value.
        /// </summary>
        public bool HasValue => !string.IsNullOrEmpty(Value);
    }
}