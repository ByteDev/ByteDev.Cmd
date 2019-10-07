using System;

namespace ByteDev.Cmd.Logging
{
    /// <summary>
    /// Represents a color theme for the logger.
    /// </summary>
    public class LoggerColorTheme
    {
        /// <summary>
        /// <see cref="T:ByteDev.Cmd.OutputColor" /> to use for debug messages.
        /// </summary>
        public OutputColor DebugColor { get; set; }

        /// <summary>
        /// <see cref="T:ByteDev.Cmd.OutputColor" /> to use for information messages.
        /// </summary>
        public OutputColor InfoColor { get; set; }

        /// <summary>
        /// <see cref="T:ByteDev.Cmd.OutputColor" /> to use for warning messages.
        /// </summary>
        public OutputColor WarnColor { get; set; }

        /// <summary>
        /// <see cref="T:ByteDev.Cmd.OutputColor" /> to use for error messages.
        /// </summary>
        public OutputColor ErrorColor { get; set; }

        /// <summary>
        /// <see cref="T:ByteDev.Cmd.OutputColor" /> to use for critical error messages.
        /// </summary>
        public OutputColor CriticalColor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Logging.LoggerColorTheme" /> class.
        /// </summary>
        public LoggerColorTheme()
        {
            DebugColor = new OutputColor(ConsoleColor.Gray);
            InfoColor = new OutputColor(ConsoleColor.White);
            WarnColor = new OutputColor(ConsoleColor.Yellow);
            ErrorColor = new OutputColor(ConsoleColor.Red);
            CriticalColor = new OutputColor(ConsoleColor.White, ConsoleColor.Red);
        }
    }
}