using System;

namespace ByteDev.Cmd
{
    public class MessageBox
    {
        private OutputColor _textColor;
        private OutputColor _borderColor;

        public string Text { get; }

        public OutputColor TextColor
        {
            get => _textColor;
            set => _textColor = value ?? ConsoleEx.GetColor();
        }

        public OutputColor BorderColor
        {
            get => _borderColor;
            set => _borderColor = value ?? ConsoleEx.GetColor();
        }

        public string[] Lines => Text.Split('\n');

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