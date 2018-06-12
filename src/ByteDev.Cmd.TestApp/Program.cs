using System;
using ByteDev.Cmd.Logging;

namespace ByteDev.Cmd.TestApp
{
    internal class Program
    {
        private static Output _output;

        private static Output Output
        {
            get { return _output ?? (_output = new Output()); }
        }

        static void Main(string[] args)
        {
            Output.Clear();

            TestOutput();
            
            TestMessageBox();

            TestLogger();

            Prompt.PressAnyKey();
        }

        private static void TestOutput()
        {
            Output.WriteLine("Default colored text");
            Output.WriteLine();

            Output.WriteRainbowLine("Crazy rainbow message");
            Output.WriteLine();

            Output.WriteLine("Writing default horizontal line...");
            Output.WriteHorizontalLine();
            Output.WriteLine();

            Output.WriteLine("Writing color block horizontal line...");
            Output.WriteHorizontalLine('=', new OutputColor(ConsoleColor.White, ConsoleColor.Gray)); 
            Output.WriteLine();

            Output.WriteAlignLeft("Aligned Left", new OutputColor(ConsoleColor.White, ConsoleColor.Red));
            Output.WriteAlignRight("Aligned Right", new OutputColor(ConsoleColor.White, ConsoleColor.DarkGreen));
            Output.WriteAlignCenter("Aligned Center", new OutputColor(ConsoleColor.White, ConsoleColor.Blue));
            Output.WriteAlignToSides("Left Bit", "Right Bit", new OutputColor(ConsoleColor.Black, ConsoleColor.Gray));
            Output.WriteLine();

            Output.WriteAlignLeft("Aligned Left (no color)");
            Output.WriteAlignRight("Aligned Right (no color)");
            Output.WriteAlignCenter("Aligned Center (no color)");
            Output.WriteAlignToSides("Left Bit (no color)", "Right Bit (no color)", new OutputColor(ConsoleColor.Black, ConsoleColor.Gray));
            Output.WriteLine();

            Output.WriteLine("Writing 3 blank lines...");
            Output.WriteBlankLines(3);

            Output.WriteLine("Default colored text");
        }

        private static void TestMessageBox()
        {
            var messageBox = new MessageBox("this is text in a message box\nsecond\nthird line")
            {
                BorderColor = new OutputColor(ConsoleColor.Red, ConsoleColor.Blue),
                TextColor = new OutputColor(ConsoleColor.White, ConsoleColor.Blue)
            };
            
            Output.Write(messageBox);
        }

        private static void TestLogger()
        {
            var logger = new Logger(LogLevel.Debug);

            logger.WriteDebug("Debug message");
            logger.WriteInfo("Info message");
            logger.WriteWarning("Warning message");
            logger.WriteError("Error message");
            logger.WriteCritical("Critical message");
        }
    }
}
