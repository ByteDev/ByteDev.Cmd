using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ByteDev.Cmd.Arguments
{
    /// <summary>
    /// Represents an allowed command line argument.
    /// </summary>
    public class CmdAllowedArg
    {
        private const string ArgNamePrefix = "-";

        private string _longName;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Arguments.CmdAllowedArg" /> class.
        /// </summary>
        /// <param name="shortName">Argument short name (a single character).</param>
        /// <param name="hasValue">Whether the argument is expected to have a value.</param>
        /// <exception cref="T:System.ArgumentException"><paramref name="shortName" /> is an invalid character.</exception>
        public CmdAllowedArg(char shortName, bool hasValue)
        {
            if (!char.IsLetter(shortName))
                throw new ArgumentException("Argument short name must be only a A-Z or a-z character.", nameof(shortName));

            ShortName = shortName;
            HasValue = hasValue;
        }

        /// <summary>
        /// Single character name for the argument.
        /// </summary>
        public char ShortName { get; }

        /// <summary>
        /// Indicates whether the argument should have a value. 
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Optional long name for the argument. Must contain only characters [A-Za-z] or be set to null.
        /// </summary>
        /// <exception cref="T:System.ArgumentException"><paramref name="value" /> contains invalid characters.</exception>
        public string LongName
        {
            get => _longName;
            set
            {
                if (value != null && !Regex.IsMatch(value, "^[A-Za-z]+$"))
                    throw new ArgumentException("Argument long name must contain only A-Z or a-z characters.", nameof(value));
                
                _longName = value;
            }
        }

        /// <summary>
        /// Optional description of the argument. Used in help text for the user.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether the argument must be supplied. Not required by default.
        /// </summary>
        public bool IsRequired { get; set; }

        internal bool HasLongName => !string.IsNullOrEmpty(LongName);

        internal bool HasDescription => !string.IsNullOrEmpty(Description);

        internal string PrefixedShortName => ArgNamePrefix + ShortName;

        internal string PrefixedLongName => ArgNamePrefix + LongName;

        internal string CreateHelpText(int lenLongestName)
        {
            const string delimiter = "     ";

            var sb = new StringBuilder();

            sb.Append(PrefixedShortName);

            if (HasDescription)
            {
                var padding = new string(' ', lenLongestName - 1);
                sb.Append(padding + delimiter + Description);
            }

            sb.AppendLine();

            if (HasLongName)
            {
                sb.Append(PrefixedLongName);

                if (HasDescription)
                {
                    var padding = new string(' ', lenLongestName - LongName.Length);
                    sb.Append(padding + delimiter + Description);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}