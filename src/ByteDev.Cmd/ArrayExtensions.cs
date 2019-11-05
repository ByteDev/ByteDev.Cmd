using System;
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
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return Enumerable.Range(0, source.GetColumnCount())
                .Select(e => source[e, rowNumber])
                .ToArray();
        }

        public static TSource[] GetColumn<TSource>(this TSource[,] source, int columnNumber)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return Enumerable.Range(0, source.GetRowCount())
                .Select(e => source[columnNumber, e])
                .ToArray();
        }

        public static int GetColumnCount<TSource>(this TSource[,] source)
        {
            return source.GetLength(0);
        }

        public static int GetRowCount<TSource>(this TSource[,] source)
        {
            return source.GetLength(1);
        }
    }
}