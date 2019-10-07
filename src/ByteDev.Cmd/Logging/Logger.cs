namespace ByteDev.Cmd.Logging
{
    /// <summary>
    /// Represents a console logger.
    /// </summary>
    public class Logger : ILogger
    {
        private readonly IOutput _output;
        private readonly LogLevel _logLevel;
        private readonly LoggerColorTheme _loggerColorTheme;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Logging.Logger" /> class.
        /// </summary>
        public Logger() : 
            this(LogLevel.Debug)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Logging.Logger" /> class.
        /// </summary>
        /// <param name="logLevel">The logging level (or more severe) at which messages should be output.</param>
        public Logger(LogLevel logLevel) : 
            this(logLevel, new LoggerColorTheme())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Logging.Logger" /> class.
        /// </summary>
        /// <param name="logLevel">The logging level (or more severe) at which messages should be output.</param>
        /// <param name="loggerColorTheme">The color theme to use when outputting logging messages.</param>
        public Logger(LogLevel logLevel, LoggerColorTheme loggerColorTheme) :
            this(logLevel, loggerColorTheme, new Output())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Logging.Logger" /> class.
        /// </summary>
        /// <param name="logLevel">The logging level (or more severe) at which messages should be output.</param>
        /// <param name="loggerColorTheme">The color theme to use when outputting logging messages.</param>
        /// <param name="output">An instance of <see cref="T:ByteDev.Cmd.IOutput" /> to write logging messages with.</param>
        public Logger(LogLevel logLevel, LoggerColorTheme loggerColorTheme, IOutput output)
        {
            _output = output;
            _logLevel = logLevel;
            _loggerColorTheme = loggerColorTheme;
        }

        /// <summary>
        /// Write a debug message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteDebug(string message)
        {
            if (_logLevel == LogLevel.Debug)
            {
                _output.WriteLine(message, _loggerColorTheme.DebugColor);
            }
        }

        /// <summary>
        /// Write a information message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteInfo(string message)
        {
            if (_logLevel == LogLevel.Debug ||
                _logLevel == LogLevel.Info)
            {
                _output.WriteLine(message, _loggerColorTheme.InfoColor);
            }
        }

        /// <summary>
        /// Write a warning message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteWarning(string message)
        {
            if (_logLevel == LogLevel.Debug ||
                _logLevel == LogLevel.Info ||
                _logLevel == LogLevel.Warning)
            {
                _output.WriteLine(message, _loggerColorTheme.WarnColor);
            }
        }

        /// <summary>
        /// Write a error message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteError(string message)
        {
            if (_logLevel == LogLevel.Debug ||
                _logLevel == LogLevel.Info ||
                _logLevel == LogLevel.Warning ||
                _logLevel == LogLevel.Error)
            {
                _output.WriteLine(message, _loggerColorTheme.ErrorColor);
            }
        }

        /// <summary>
        /// Write a critical error message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        public void WriteCritical(string message)
        {
            _output.WriteLine(message, _loggerColorTheme.CriticalColor);
        }
    }
}