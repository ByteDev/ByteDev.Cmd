namespace ByteDev.Cmd.Arguments
{
    /// <summary>
    /// Represents an allowed command line argument.
    /// </summary>
    public class CmdAllowedArg
    {
        private const string ArgNamePrefix = "-";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Arguments.CmdAllowedArg" /> class.
        /// </summary>
        /// <param name="shortName">Argument short name (a single character).</param>
        /// <param name="hasValue">Whether the argument should have a value.</param>
        public CmdAllowedArg(char shortName, bool hasValue)
        {
            ShortName = shortName;
            HasValue = hasValue;
        }

        /// <summary>
        /// Short name for the argument. Must be a single character long.
        /// </summary>
        public char ShortName { get; }

        /// <summary>
        /// Indicates whether the argument should have a value. 
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Optional long name for the argument.
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Optional description of the argument. Used in help text for the user.
        /// </summary>
        public string Description { get; set; }

        internal bool HasLongName => !string.IsNullOrEmpty(LongName);

        internal bool HasDescription => !string.IsNullOrEmpty(Description);

        internal string PrefixedShortName => ArgNamePrefix + ShortName;

        internal string PrefixedLongName => ArgNamePrefix + LongName;
    }
}