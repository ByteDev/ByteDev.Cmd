namespace ByteDev.Cmd.Logging
{
    public interface ILogger
    {
        void WriteDebug(string message);
        void WriteInfo(string message);
        void WriteWarning(string message);
        void WriteError(string message);
        void WriteCritical(string message);
    }
}