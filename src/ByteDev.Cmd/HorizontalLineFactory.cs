using ByteDev.Cmd.Tables;
using ByteDev.Cmd.Tables.Borders;

namespace ByteDev.Cmd
{
    internal static class HorizontalLineFactory
    {
        public static string Create(MessageBox messageBox)
        {
            var longestLine = messageBox.Lines.GetLongestElement();

            return new string(messageBox.BorderStyle.HorizontalLine, longestLine.Length);
        }

        public static string Create(Table table)
        {
            var totalValueWidths = table.Columns * table.GetLongestElementLength();

            var totalPaddingsLength = (table.LeftPadding.Length + table.RightPadding.Length) * table.Columns;

            var charLength = totalValueWidths + totalPaddingsLength;

            return new string(table.BorderStyle.HorizontalLine, charLength);
        }

        public static string CreateTop(string horizontalLine, IBorderStyle borderStyle)
        {
            return $"{borderStyle.LeftTop}{horizontalLine}{borderStyle.RightTop}";
        }

        public static string CreateBottom(string horizontalLine, IBorderStyle borderStyle)
        {
            return $"{borderStyle.LeftBottom}{horizontalLine}{borderStyle.RightBottom}";
        }
    }
}