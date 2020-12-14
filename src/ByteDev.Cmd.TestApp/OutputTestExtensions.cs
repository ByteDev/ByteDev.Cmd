using System;

namespace ByteDev.Cmd.TestApp
{
    public static class OutputTestExtensions
    {
        public static void WriteTestHeader(this Output source, string header)
        {
            source.WriteHorizontalLine('=');
            source.WriteLine();
            source.WriteLine($"***** {header} *****");
            source.WriteLine();
        }

        public static void TestOutput(this Output source)
        {
            source.WriteTestHeader("Testing Output");

            source.Write("ABC");
            source.Write("XYZ",new OutputColor(ConsoleColor.DarkRed, ConsoleColor.Blue));
            source.WriteLine();

            source.WriteLine("Default colored text");
            source.WriteLine("Set colored text", new OutputColor(ConsoleColor.DarkRed, ConsoleColor.Blue));
            source.WriteLine();

            source.Write('A');
            source.Write('B',new OutputColor(ConsoleColor.DarkRed, ConsoleColor.Blue));
            source.WriteLine();

            source.WriteLine('A');
            source.WriteLine('B', new OutputColor(ConsoleColor.DarkRed, ConsoleColor.Blue));
            source.WriteLine();

            source.WriteRainbowLine("Crazy rainbow message");
            source.WriteRainbowLine("Got a headache yet?", new []
            {
                new OutputColor(ConsoleColor.Yellow, ConsoleColor.DarkCyan), 
                new OutputColor(ConsoleColor.Red, ConsoleColor.DarkBlue), 
                new OutputColor(ConsoleColor.Green, ConsoleColor.DarkRed),
                new OutputColor(ConsoleColor.Blue, ConsoleColor.White), 
                new OutputColor(ConsoleColor.Gray, ConsoleColor.Yellow)
            });
            source.WriteLine();

            source.WriteLine("Writing default horizontal line...");
            source.WriteHorizontalLine();
            source.WriteLine();

            source.WriteLine("Writing color block horizontal line...");
            source.WriteHorizontalLine('=', new OutputColor(ConsoleColor.White, ConsoleColor.Gray));
            source.WriteHorizontalLine(' ', new OutputColor(ConsoleColor.White, ConsoleColor.DarkGray));
            source.WriteLine();

            source.WriteAlignLeft("Aligned Left", new OutputColor(ConsoleColor.White, ConsoleColor.Red));
            source.WriteAlignRight("Aligned Right", new OutputColor(ConsoleColor.White, ConsoleColor.DarkGreen));
            source.WriteAlignCenter("Aligned Center", new OutputColor(ConsoleColor.White, ConsoleColor.Blue));
            source.WriteAlignToSides("Left Bit", "Right Bit", new OutputColor(ConsoleColor.Black, ConsoleColor.Gray));
            source.WriteLine();

            source.WriteAlignLeft("Aligned Left (no color)");
            source.WriteAlignRight("Aligned Right (no color)");
            source.WriteAlignCenter("Aligned Center (no color)");
            source.WriteAlignToSides("Left Bit (no color)", "Right Bit (no color)");
            source.WriteLine();

            source.WriteLine("Writing 3 blank lines...");
            source.WriteBlankLines(3);

            source.WriteLine("Default colored text");
            source.WriteLine();

            source.WriteLine("---------1---------2---------3---------4---------5---------6---------7---------8---------9---------1");

            const string returnText = "This is some text\nthis is some tex and that is some text. My name is\n John Smith";

            source.WriteWrap(returnText, new WriteWrapOptions
            {
                LineLength = 20,
                PadEnds = true,
                OutputColor = new OutputColor(ConsoleColor.Black, ConsoleColor.Yellow)
            });
            source.WriteLine();
            source.WriteLine();

            const string longText = "This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text. This is some text, and this is some more text.";

            source.WriteWrap(longText, new WriteWrapOptions
            {
                OutputColor = new OutputColor(ConsoleColor.Black, ConsoleColor.Yellow)
            });
            source.WriteLine();
        }
    }
}