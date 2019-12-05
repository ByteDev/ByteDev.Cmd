using System;

namespace ByteDev.Cmd
{
    /// <summary>
    /// Represents the colors to use when writing to the console.
    /// </summary>
    public class OutputColor
    {
        /// <summary>
        /// The output foreground color.
        /// </summary>
        public ConsoleColor ForegroundColor { get; }

        /// <summary>
        /// The output background color.
        /// </summary>
        public ConsoleColor BackgroundColor { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.OutputColor" /> class.
        /// </summary>
        /// <param name="foregroundColor">The output foreground color.</param>
        public OutputColor(ConsoleColor foregroundColor) : this(foregroundColor, Console.BackgroundColor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.OutputColor" /> class.
        /// </summary>
        /// <param name="foregroundColor">The output foreground color.</param>
        /// <param name="backgroundColor">The output background color.</param>
        public OutputColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }
    }
}