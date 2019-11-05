using System.Linq;

namespace ByteDev.Cmd
{
    internal static class ArrayExtensions
    {
        public static void Populate<TSource>(this TSource[,] source, TSource value)
        {
            for (var i = 0; i < source.GetLength(0); i++)
            {
                for (var j = 0; j < source.GetLength(1); j++)
                {
                    source[i, j] = value;
                }
            }
        }

        public static TSource[] GetRow<TSource>(this TSource[,] source, int rowNumber)
        {
            var rowCount = source.GetLength(1);

            return Enumerable.Range(0, rowCount)
                .Select(e => source[e, rowNumber])
                .ToArray();
        }

        public static TSource[] GetColumn<TSource>(this TSource[,] source, int columnNumber)
        {
            var columnCount = source.GetLength(0);

            return Enumerable.Range(0, columnCount)
                .Select(e => source[columnNumber, e])
                .ToArray();
        }
    }
}