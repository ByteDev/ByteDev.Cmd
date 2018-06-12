using System;

namespace ByteDev.Cmd
{
    public class Output : IOutput
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void Write(string text, OutputColor color)
        {
            ConsoleEx.SetColor(color);
            Write(text);
            Console.ResetColor();
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string text, OutputColor color)
        {
            ConsoleEx.SetColor(color);
            WriteLine(text);
            Console.ResetColor();
        }

        public void WriteRainbowLine(string text)
        {
            OutputColor[] defaultRainbowColors =
            {
                new OutputColor(ConsoleColor.Red),
                new OutputColor(ConsoleColor.Yellow),
                new OutputColor(ConsoleColor.Blue),
                new OutputColor(ConsoleColor.White)
            };

            WriteRainbowLine(text, defaultRainbowColors);
        }

        public void WriteRainbowLine(string text, OutputColor[] colors)
        {
            if(colors == null)
                throw new ArgumentNullException(nameof(colors));

            var colorIndex = 0;

            for (var i = 0; i < text.Length; i++)
            {
                var ch = text.Substring(i, 1);
                var color = colors[colorIndex];

                Write(ch, color);

                colorIndex++;

                if (colorIndex >= colors.Length)
                    colorIndex = 0;
            }

            WriteLine();
            Console.ResetColor();
        }

        public void WriteAlignLeft(string text, OutputColor color = null)
        {
            WriteLine(text.PadRight(Console.WindowWidth - 1), color);
        }

        public void WriteAlignRight(string text, OutputColor color = null)
        {
            WriteLine(text.PadLeft(Console.WindowWidth - 1), color);
        }

        public void WriteAlignCenter(string message, OutputColor color = null)
        {
            decimal remainingWidth = Console.WindowWidth - message.Length - 1;

            var rightSize = (int)Math.Round(remainingWidth / 2);
            var leftSize = (int)(remainingWidth - rightSize);

            Write(new string(' ', leftSize), color);
            Write(message, color);
            WriteLine(new string(' ', rightSize), color);
        }

        public void WriteAlignToSides(string leftText, string rightText, OutputColor color = null)
        {
            Write(leftText, color);

            var size = Console.WindowWidth - 1 - leftText.Length - rightText.Length;
            if (size > 0)
            {
                Write(new string(' ', size), color);
            }

            WriteLine(rightText, color);
        }

        public void WriteHorizontalLine(char character = '-', OutputColor color = null)
        {
            WriteLine(new string(character, Console.WindowWidth - 1), color);
        }

        public void WriteBlankLines(int numberOfLines = 1)
        {
            for (var i = 0; i < numberOfLines; i++)
            {
                WriteLine();
            }
        }

        public void Write(MessageBox messageBox)
        {
            var horizonalLine = CreateHorizonalLine(messageBox.Lines);
            
            WriteLine($"╔{horizonalLine}╗", messageBox.BorderColor);

            foreach (var line in messageBox.Lines)
            {
                var paddedLine = line.PadRight(horizonalLine.Length);

                Write("║", messageBox.BorderColor);
                Write(paddedLine, messageBox.TextColor);
                WriteLine("║", messageBox.BorderColor);
            }

            WriteLine($"╚{horizonalLine}╝", messageBox.BorderColor);
        }

        private static string CreateHorizonalLine(string[] lines)
        {
            var longestLineLen = lines.GetLongestElementLength();

            return new string('═', longestLineLen);
        }
    }
}