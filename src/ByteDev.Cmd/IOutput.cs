namespace ByteDev.Cmd
{
    public interface IOutput
    {
        void Clear();

        void Write(string text);
        void Write(string text, OutputColor color);
        void Write(MessageBox messageBox);

        void WriteLine();
        void WriteLine(string text);
        void WriteLine(string text, OutputColor color);

        void WriteRainbowLine(string text);
        void WriteRainbowLine(string text, OutputColor[] colors);

        void WriteAlignLeft(string text, OutputColor color = null);
        void WriteAlignRight(string text, OutputColor color = null);
        void WriteAlignCenter(string message, OutputColor color = null);
        void WriteAlignToSides(string leftText, string rightText, OutputColor color = null);

        void WriteHorizontalLine(char character = '-', OutputColor color = null);

        void WriteBlankLines(int numberOfLines = 1);
    }
}