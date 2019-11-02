using System.Collections.Generic;

namespace ByteDev.Cmd
{
    internal static class HorizontalLineFactory
    {
        public static string Create(IEnumerable<string> lines)
        {
            var longestLine = lines.GetLongestElement();

            return Create(longestLine.Length);
        }

        public static string Create(Table table)
        {
            var totalValueWidths = table.Columns * table.GetLongestValueLength();

            var totalPaddingsLength = (table.LeftPadding.Length + table.RightPadding.Length) * table.Columns;

            var charLength = totalValueWidths + totalPaddingsLength;

            return Create(charLength);
        }

        private static string Create(int length)
        {
            return new string('═', length);
        }
    }
}