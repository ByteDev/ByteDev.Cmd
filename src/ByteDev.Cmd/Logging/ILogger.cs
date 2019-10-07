namespace ByteDev.Cmd.Logging
{
    /// <summary>
    /// Represents the interface to a logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write a debug message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        void WriteDebug(string message);
        
        /// <summary>
        /// Write a information message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        void WriteInfo(string message);

        /// <summary>
        /// Write a warning message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        void WriteWarning(string message);
        
        /// <summary>
        /// Write a error message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        void WriteError(string message);
        
        /// <summary>
        /// Write a critical error message.
        /// </summary>
        /// <param name="message">The message to output.</param>
        void WriteCritical(string message);
    }
}