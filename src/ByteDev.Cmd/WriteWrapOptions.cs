using System;

namespace ByteDev.Cmd
{
    /// <summary>
    /// Represents options for the WriteWrap operation.
    /// </summary>
    public class WriteWrapOptions
    {
        private int _lineLength;

        /// <summary>
        /// The desired line length in characters. By default will be the console window
        /// width minus one.
        /// </summary>
        public int LineLength
        {
            get
            {
                if (_lineLength < 1)
                    _lineLength = Console.WindowWidth - 1;

                return _lineLength;
            }
            set => _lineLength = value;
        }

        /// <summary>
        /// If true any trailing space for a line will be padded with spaces.
        /// True by default.
        /// </summary>
        public bool PadEnds { get; set; } = true;

        /// <summary>
        /// The output color to use when writing each line.
        /// </summary>
        public OutputColor OutputColor { get; set; }
    }
}