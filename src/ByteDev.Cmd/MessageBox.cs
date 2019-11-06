using System;
using ByteDev.Cmd.Borders;

namespace ByteDev.Cmd
{
    /// <summary>
    /// Represents a console message box.
    /// </summary>
    public class MessageBox
    {
        private OutputColor _textColor;
        private OutputColor _borderColor;
        private IBorderStyle _borderStyle;

        /// <summary>
        /// The text inside the message box.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Color of the text inside the message box.
        /// </summary>
        public OutputColor TextColor
        {
            get => _textColor ?? (_textColor = ConsoleEx.GetColor());
            set => _textColor = value;
        }

        /// <summary>
        /// Border style.
        /// </summary>
        public IBorderStyle BorderStyle
        {
            get => _borderStyle ?? (_borderStyle = new BorderDouble());
            set => _borderStyle = value;
        }

        /// <summary>
        /// Color of the message box border.
        /// </summary>
        public OutputColor BorderColor
        {
            get => _borderColor ?? (_borderColor = ConsoleEx.GetColor());
            set => _borderColor = value;
        }

        /// <summary>
        /// The text inside the message box as an array of lines.
        /// </summary>
        public string[] Lines => Text.Split('\n');

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.MessageBox" /> class.
        /// </summary>
        /// <param name="text">The text inside the message box.</param>
        /// <exception cref="T:System.ArgumentException"><paramref name="text" /> is null or empty.</exception>
        public MessageBox(string text)
        {
            if(string.IsNullOrEmpty(text))
                throw new ArgumentException("Text was null or empty.", nameof(text));

            Text = text;

            _textColor = ConsoleEx.GetColor();
            _borderColor = ConsoleEx.GetColor();
        }
    }
}