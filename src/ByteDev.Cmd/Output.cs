using System;
using ByteDev.Cmd.Lists;
using ByteDev.Cmd.Tables;

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

        #region Write

        /// <summary>
        /// Write character to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        public void Write(char c)
        {
            Write(c, null);
        }

        /// <summary>
        /// Write character to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the character.</param>
        public void Write(char c, OutputColor color)
        {
            if (color == null)
            {
                Console.Write(c);
            }
            else
            {
                ConsoleEx.SetColor(color);
                Console.Write(c);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Write text to the console.
        /// </summary>
        /// <param name="text">The text to write to the console.</param>
        public void Write(string text)
        {
            Write(text, null);
        }

        /// <summary>
        /// Write text to the console.
        /// </summary>
        /// <param name="text">The text to write to the console.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        public void Write(string text, OutputColor color)
        {
            if (color == null)
            {
                Console.Write(text);
            }
            else
            {
                ConsoleEx.SetColor(color);
                Console.Write(text);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Write an unordered list to the console.
        /// </summary>
        /// <param name="unorderedList">The unordered list to write to console.</param>
        public void Write(UnorderedList unorderedList)
        {
            if(unorderedList == null)
                throw new ArgumentNullException(nameof(unorderedList));

            foreach (var item in unorderedList.Items)
            {
                WriteLine($"{unorderedList.ItemPrefix}{item}", unorderedList.ItemColor);
            }
        }

        /// <summary>
        /// Write an ordered list to the console.
        /// </summary>
        /// <param name="orderedList">The ordered list to write to the console.</param>
        public void Write(OrderedList orderedList)
        {
            if(orderedList == null)
                throw new ArgumentNullException(nameof(orderedList));

            var counter = orderedList.ItemStartingNumber;

            foreach (var item in orderedList.Items)
            {
                WriteLine($"{orderedList.GetNumberFormatted(counter)}{orderedList.ItemNumberDelimiter}{item}", orderedList.ItemColor);
                counter++;
            }
        }

        /// <summary>
        /// Write a message box to the console.
        /// </summary>
        /// <param name="messageBox">The message box to write.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="messageBox" /> is null.</exception>
        public void Write(MessageBox messageBox)
        {
            if(messageBox == null)
                throw new ArgumentNullException(nameof(messageBox));

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
        /// <exception cref="T:System.ArgumentNullException"><paramref name="table" /> is null.</exception>
        public void Write(Table table)
        {
            if(table == null)
                throw new ArgumentNullException(nameof(table));

            var line = HorizontalLineFactory.Create(table);

            WriteLine(HorizontalLineFactory.CreateTop(line, table.BorderStyle), table.BorderColor);

            for (var rowNumber=0; rowNumber < table.Rows; rowNumber++)
            {
                WriteTableRow(table, rowNumber);
            }
            
            WriteLine(HorizontalLineFactory.CreateBottom(line, table.BorderStyle), table.BorderColor);
        }
        
        #endregion

        #region WriteLine

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
            WriteLine(c, null);
        }

        /// <summary>
        /// Write character and new line to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the character.</param>
        public void WriteLine(char c, OutputColor color)
        {
            if (color == null)
            {
                Console.WriteLine(c);
            }
            else
            {
                ConsoleEx.SetColor(color);
                Console.WriteLine(c);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Write a text line to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        public void WriteLine(string text)
        {
            WriteLine(text, null);
        }

        /// <summary>
        /// Write a text line to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        public void WriteLine(string text, OutputColor color)
        {
            if (color == null)
            {
                Console.WriteLine(text);
            }
            else
            {
                ConsoleEx.SetColor(color);
                Console.WriteLine(text);
                Console.ResetColor();
            }
        }

        #endregion

        #region WriteRainbowLine

        /// <summary>
        /// Write a line of text changing the color of each character.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        public void WriteRainbowLine(string text)
        {
            OutputColor[] defaultRainbowColors =
            {
                new OutputColor(ConsoleColor.Red),
                new OutputColor(ConsoleColor.Yellow),
                new OutputColor(ConsoleColor.Green),
                new OutputColor(ConsoleColor.Blue)
            };

            WriteRainbowLine(text, defaultRainbowColors);
        }

        /// <summary>
        /// Write a line of text changing the color of each character to the respective color in <paramref name="colors" />.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="colors">Array of <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing out each character of the text.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="colors" /> is null.</exception>
        public void WriteRainbowLine(string text, OutputColor[] colors)
        {
            if (colors == null)
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

        #endregion

        #region WriteAlign...

        /// <summary>
        /// Write text left aligned to the console. 
        /// </summary>
        /// <param name="text">The text to be written.</param>
        public void WriteAlignLeft(string text)
        {
            WriteAlignLeft(text, null);
        }

        /// <summary>
        /// Write text left aligned to the console. 
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        public void WriteAlignLeft(string text, OutputColor color)
        {
            WriteLine(text.PadRight(Console.WindowWidth - 1), color);
        }

        /// <summary>
        /// Write text right aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        public void WriteAlignRight(string text)
        {
            WriteAlignRight(text, null);
        }

        /// <summary>
        /// Write text right aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        public void WriteAlignRight(string text, OutputColor color)
        {
            WriteLine(text.PadLeft(Console.WindowWidth - 1), color);
        }

        /// <summary>
        /// Write text center aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        public void WriteAlignCenter(string text)
        {
            WriteAlignCenter(text, null);
        }

        /// <summary>
        /// Write text center aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        public void WriteAlignCenter(string text, OutputColor color)
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
        public void WriteAlignToSides(string leftText, string rightText)
        {
            WriteAlignToSides(leftText, rightText, null);
        }

        /// <summary>
        /// Write left aligned and right aligned text to the console.
        /// </summary>
        /// <param name="leftText">The text to write to the left.</param>
        /// <param name="rightText">The text to write to the right.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        public void WriteAlignToSides(string leftText, string rightText, OutputColor color)
        {
            Write(leftText, color);

            var size = Console.WindowWidth - 1 - leftText.Length - rightText.Length;

            if (size > 0)
            {
                Write(new string(' ', size), color);
            }

            WriteLine(rightText, color);
        }

        #endregion

        /// <summary>
        /// Write a horizontal line of repeated hyphen characters to the console.
        /// </summary>
        public void WriteHorizontalLine()
        {
            WriteHorizontalLine('-');
        }

        /// <summary>
        /// Write a horizontal line of repeated characters to the console.
        /// </summary>
        /// <param name="character">Character repeated in the horizontal line.</param>
        public void WriteHorizontalLine(char character)
        {
            WriteHorizontalLine(character, null);
        }

        /// <summary>
        /// Write a horizontal line of repeated characters to the console.
        /// </summary>
        /// <param name="character">Character repeated in the horizontal line.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing horizontal line's text.</param>
        public void WriteHorizontalLine(char character, OutputColor color)
        {
            WriteLine(new string(character, Console.WindowWidth - 1), color);
        }
        
        /// <summary>
        /// Write a number of blank lines to the console.
        /// </summary>
        /// <param name="numberOfLines">The number of blank lines to write.</param>
        public void WriteBlankLines(int numberOfLines)
        {
            for (var i = 0; i < numberOfLines; i++)
            {
                WriteLine();
            }
        }

        /// <summary>
        /// Write wrapped text to the console.
        /// </summary>
        /// <param name="text">Text to write.</param>
        public void WriteWrap(string text)
        {
            WriteWrap(text, new WriteWrapOptions());
        }

        /// <summary>
        /// Write wrapped text to the console.
        /// </summary>
        /// <param name="text">Text to write.</param>
        /// <param name="options">Options for altering how the text is written.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="options" /> is null.</exception>
        public void WriteWrap(string text, WriteWrapOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var charCount = 0;
            string prevWord = string.Empty;

            var words = text.Replace("\n", "\n ").Split(' ');

            foreach (var word in words)
            {
                if (charCount + word.Length + 1 > options.LineLength ||            // gonna spill over the end (+1 for space)
                    prevWord.EndsWith("\n"))     
                {
                    if (options.PadEnds)
                        WriteSpacePadding(charCount, options.LineLength, options.OutputColor);
                    
                    WriteLine();
                    charCount = 0;
                }

                if (charCount != 0)
                {
                    Write(" ", options.OutputColor);
                    charCount++;
                }

                Write(word.SanitizeWord(), options.OutputColor);
                charCount += word.GetWordLength();

                prevWord = word;
            }
        }
        
        private void WriteSpacePadding(int charCount, int lineLen, OutputColor color)
        {
            var padLen = lineLen - charCount;

            if (padLen > 0)
            {
                Write(new string(' ', padLen), color);
            }
        }

        private void WriteTableRow(Table table, int rowNumber)
        {
            Write(table.BorderStyle.VerticalLine, table.BorderColor);

            var longestValue = table.GetLongestCellValueLength();

            for (var colNumber = 0; colNumber < table.Columns; colNumber++)
            {
                var cell = table.GetCell(new CellPosition(colNumber, rowNumber)) ?? new Cell();

                var valueFormatted = cell.ToStringFormatted(longestValue, table.LeftPadding, table.RightPadding);

                Write(valueFormatted, cell.ValueColor ?? table.ValueColor);
            }

            WriteLine(table.BorderStyle.VerticalLine, table.BorderColor);
        }
    }
}