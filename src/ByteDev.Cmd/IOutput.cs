﻿using ByteDev.Cmd.Lists;
using ByteDev.Cmd.Tables;

namespace ByteDev.Cmd
{
    /// <summary>
    /// Represents a interface for writing text to the console.
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Clear the console output.
        /// </summary>
        void Clear();

        /// <summary>
        /// Write character to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        void Write(char c);

        /// <summary>
        /// Write character to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the character.</param>
        void Write(char c, OutputColor color);

        /// <summary>
        /// Write text to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        void Write(string text);

        /// <summary>
        /// Write text to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        void Write(string text, OutputColor color);

        /// <summary>
        /// Write an unordered list to the console.
        /// </summary>
        /// <param name="unorderedList">The unordered list to write to console.</param>
        void Write(UnorderedList unorderedList);

        /// <summary>
        /// Write an ordered list to the console.
        /// </summary>
        /// <param name="orderedList">The ordered list to write to the console.</param>
        void Write(OrderedList orderedList);

        /// <summary>
        /// Write a message box to the console.
        /// </summary>
        /// <param name="messageBox">The message box to write.</param>
        void Write(MessageBox messageBox);

        /// <summary>
        /// Write a table to the console.
        /// </summary>
        /// <param name="table">The table to write.</param>
        void Write(Table table);

        /// <summary>
        /// Write a blank line to the console.
        /// </summary>
        void WriteLine();
        
        /// <summary>
        /// Write character and new line to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        void WriteLine(char c);

        /// <summary>
        /// Write character and new line to the console.
        /// </summary>
        /// <param name="c">The character to write to the console.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the character.</param>
        void WriteLine(char c, OutputColor color);

        /// <summary>
        /// Write a text line to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        void WriteLine(string text);

        /// <summary>
        /// Write a text line to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        void WriteLine(string text, OutputColor color);

        /// <summary>
        /// Write a line of text changing the color of each character.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        void WriteRainbowLine(string text);

        /// <summary>
        /// Write a line of text changing the color of each character to the respective color in <paramref name="colors" />.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="colors">Array of <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing out each character of the text.</param>
        void WriteRainbowLine(string text, OutputColor[] colors);

        /// <summary>
        /// Write text left aligned to the console. 
        /// </summary>
        /// <param name="text">The text to be written.</param>
        void WriteAlignLeft(string text);

        /// <summary>
        /// Write text left aligned to the console. 
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        void WriteAlignLeft(string text, OutputColor color);

        /// <summary>
        /// Write text right aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        void WriteAlignRight(string text);

        /// <summary>
        /// Write text right aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        void WriteAlignRight(string text, OutputColor color);

        /// <summary>
        /// Write text center aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        void WriteAlignCenter(string text);

        /// <summary>
        /// Write text center aligned to the console.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        void WriteAlignCenter(string text, OutputColor color);

        /// <summary>
        /// Write left aligned and right aligned text to the console.
        /// </summary>
        /// <param name="leftText">The text to write to the left.</param>
        /// <param name="rightText">The text to write to the right.</param>
        void WriteAlignToSides(string leftText, string rightText);

        /// <summary>
        /// Write left aligned and right aligned text to the console.
        /// </summary>
        /// <param name="leftText">The text to write to the left.</param>
        /// <param name="rightText">The text to write to the right.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing the text.</param>
        void WriteAlignToSides(string leftText, string rightText, OutputColor color);

        /// <summary>
        /// Write a horizontal line of hyphen characters to the console.
        /// </summary>
        void WriteHorizontalLine();

        /// <summary>
        /// Write a horizontal line of characters to the console.
        /// </summary>
        /// <param name="character">Character repeated in the horizontal line.</param>
        void WriteHorizontalLine(char character);

        /// <summary>
        /// Write a horizontal line of characters to the console.
        /// </summary>
        /// <param name="character">Character repeat in the horizontal line.</param>
        /// <param name="color">The <see cref="T:ByteDev.Cmd.OutputColor" /> to use when writing horizontal line's text.</param>
        void WriteHorizontalLine(char character, OutputColor color);
        
        /// <summary>
        /// Write a number of blank lines to the console.
        /// </summary>
        /// <param name="numberOfLines">The number of blank lines to write.</param>
        void WriteBlankLines(int numberOfLines);

        /// <summary>
        /// Write wrapped text to the console.
        /// </summary>
        /// <param name="text">Text to write.</param>
        void WriteWrap(string text);

        /// <summary>
        /// Write wrapped text to the console.
        /// </summary>
        /// <param name="text">Text to write.</param>
        /// <param name="options">Options for altering how the text is written.</param>
        void WriteWrap(string text, WriteWrapOptions options);
    }
}