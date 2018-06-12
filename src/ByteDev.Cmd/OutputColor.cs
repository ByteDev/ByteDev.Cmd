using System;

namespace ByteDev.Cmd
{
    public class OutputColor
    {
        public ConsoleColor ForegroundColor { get; }
        public ConsoleColor BackgroundColor { get; }

        public OutputColor(ConsoleColor foregroundColor) :
            this(foregroundColor, ConsoleColor.Black)
        {
        }

        public OutputColor(ConsoleColor foregroundColor,
            ConsoleColor backgroundColor)
        {
            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
        }
    }
}