using System;

namespace ByteDev.Cmd
{
    /// <summary>
    /// Represents a class for writing to the console.
    /// </summary>
    public class Output : IOutput
    {
        /// <summary>
        /// Clear the console output.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Write character to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        public void Write(char c)
        {
            Console.Write(c);
        }

        /// <summary>
        /// Write character to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the character.</param>
        public void Write(char c, OutputColor color)
        {
            Write(c.ToString(), color);
        }

        /// <summary>
        /// Write text to the console.
        /// </summary>
        /// <param name="text">The text to write to the console.</param>
        public void Write(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Write text to the console.
        /// </summary>
        /// <param name="text">The text to write to the console.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        /// /// <exception cref="T:System.ArgumentNullException"><paramref name="color" /> is null.</exception>
        public void Write(string text, OutputColor color)
        {
            if (color == null)
                throw new ArgumentNullException(nameof(color));

            ConsoleEx.SetColor(color);
            Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Write a message box to the console.
        /// </summary>
        /// <param name="messageBox">The message box to write.</param>
        public void Write(MessageBox messageBox)
        {
            var horizontalLine = HorizontalLineFactory.Create(messageBox);
            
            WriteLine(HorizontalLineFactory.CreateTop(horizontalLine, messageBox.BorderStyle), messageBox.BorderColor);

            foreach (var line in messageBox.Lines)
            {
                var paddedLine = line.PadRight(horizontalLine.Length);

                Write(messageBox.BorderStyle.VerticalLine, messageBox.BorderColor);
                Write(paddedLine, messageBox.TextColor);
                WriteLine(messageBox.BorderStyle.VerticalLine, messageBox.BorderColor);
            }

            WriteLine(HorizontalLineFactory.CreateBottom(horizontalLine, messageBox.BorderStyle), messageBox.BorderColor);
        }
        
        /// <summary>
        /// Write a table to the console.
        /// </summary>
        /// <param name="table">The table to write.</param>
        public void Write(Table table)
        {
            var line = HorizontalLineFactory.Create(table);

            WriteLine(HorizontalLineFactory.CreateTop(line, table.BorderStyle), table.BorderColor);

            for (var row=0; row < table.Rows; row++)
            {
                Write(table.BorderStyle.VerticalLine, table.BorderColor);
                Write(table.GetRowText(row), table.ValueColor);
                WriteLine(table.BorderStyle.VerticalLine, table.BorderColor);
            }
            
            WriteLine(HorizontalLineFactory.CreateBottom(line, table.BorderStyle), table.BorderColor);
        }

        /// <summary>
        /// Write a blank line to the console.
        /// </summary>
        public void WriteLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Write character and new line to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        public void WriteLine(char c)
        {
            Console.Write(c);
        }

        /// <summary>
        /// Write character and new line to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the character.</param>
        public void WriteLine(char c, OutputColor color)
        {
            WriteLine(c.ToString(), color);
        }

        /// <summary>
        /// Write a text line to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Write a text line to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="color" /> is null.</exception>
        public void WriteLine(string text, OutputColor color)
        {
            if(color == null)
                throw new ArgumentNullException(nameof(color));

            ConsoleEx.SetColor(color);
            WriteLine(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Write a line of text in the default rainbow colors.
        /// </summary>
        /// <param name="text">The text to be written.</param>
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

        /// <summary>
        /// Write a line of text in the default rainbow colors.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="colors">Array of <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing out each character of the text.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="colors" /> is null.</exception>
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

        /// <summary>
        /// Write text left aligned to the console. 
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        public void WriteAlignLeft(string text, OutputColor color = null)
        {
            WriteLine(text.PadRight(Console.WindowWidth - 1), color);
        }

        /// <summary>
        /// Write text right aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        public void WriteAlignRight(string text, OutputColor color = null)
        {
            WriteLine(text.PadLeft(Console.WindowWidth - 1), color);
        }

        /// <summary>
        /// Write text center aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        public void WriteAlignCenter(string text, OutputColor color = null)
        {
            decimal remainingWidth = Console.WindowWidth - text.Length - 1;

            var rightSize = (int)Math.Round(remainingWidth / 2);
            var leftSize = (int)(remainingWidth - rightSize);

            Write(new string(' ', leftSize), color);
            Write(text, color);
            WriteLine(new string(' ', rightSize), color);
        }

        /// <summary>
        /// Write left aligned and right aligned text to the console.
        /// </summary>
        /// <param name="leftText">The text to write to the left.</param>
        /// <param name="rightText">The text to write to the right.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
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

        /// <summary>
        /// Write a horizontal line of characters to the console.
        /// </summary>
        /// <param name="character">Character repeat in the horizontal line.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing horizontal line's text.</param>
        public void WriteHorizontalLine(char character = '-', OutputColor color = null)
        {
            WriteLine(new string(character, Console.WindowWidth - 1), color);
        }

        /// <summary>
        /// Write a number of blank lines to the console.
        /// </summary>
        /// <param name="numberOfLines">The number of blank lines to write.</param>
        public void WriteBlankLines(int numberOfLines = 1)
        {
            for (var i = 0; i < numberOfLines; i++)
            {
                WriteLine();
            }
        }
    }
}