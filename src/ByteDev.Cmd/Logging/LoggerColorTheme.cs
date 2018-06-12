using System;

namespace ByteDev.Cmd.Logging
{
    public class LoggerColorTheme
    {
        public OutputColor DebugColor { get; set; }
        public OutputColor InfoColor { get; set; }
        public OutputColor WarnColor { get; set; }
        public OutputColor ErrorColor { get; set; }
        public OutputColor CriticalColor { get; set; }

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