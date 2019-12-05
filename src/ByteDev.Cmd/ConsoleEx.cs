using System;

namespace ByteDev.Cmd
{
    internal static class ConsoleEx
    {
        public static OutputColor GetColor()
        {
            return new OutputColor(Console.ForegroundColor, Console.BackgroundColor);
        }

        public static void SetColor(OutputColor color)
        {
            Console.ForegroundColor = color.ForegroundColor;
            Console.BackgroundColor = color.BackgroundColor;
        }
    }
}