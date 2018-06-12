namespace ByteDev.Cmd.Logging
{
    public class Logger : ILogger
    {
        private readonly IOutput _output;
        private readonly LogLevel _logLevel;
        private readonly LoggerColorTheme _loggerColorTheme;

        public Logger() : 
            this(LogLevel.Debug)
        {
        }

        public Logger(LogLevel logLevel) : 
            this(logLevel, new LoggerColorTheme())
        {
        }

        public Logger(LogLevel logLevel, LoggerColorTheme loggerColorTheme) :
            this(logLevel, loggerColorTheme, new Output())
        {
        }

        public Logger(LogLevel logLevel, LoggerColorTheme loggerColorTheme, IOutput output)
        {
            _output = output;
            _logLevel = logLevel;
            _loggerColorTheme = loggerColorTheme;
        }

        public void WriteDebug(string message)
        {
            if (_logLevel == LogLevel.Debug)
            {
                _output.WriteLine(message, _loggerColorTheme.DebugColor);
            }
        }

        public void WriteInfo(string message)
        {
            if (_logLevel == LogLevel.Debug ||
                _logLevel == LogLevel.Info)
            {
                _output.WriteLine(message, _loggerColorTheme.InfoColor);
            }
        }

        public void WriteWarning(string message)
        {
            if (_logLevel == LogLevel.Debug ||
                _logLevel == LogLevel.Info ||
                _logLevel == LogLevel.Warning)
            {
                _output.WriteLine(message, _loggerColorTheme.WarnColor);
            }
        }

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

        public void WriteCritical(string message)
        {
            _output.WriteLine(message, _loggerColorTheme.CriticalColor);
        }
    }
}