using System;
using System.Collections.Generic;

namespace ByteDev.Cmd
{
    internal static class EnumerableExtensions
    {
        public static int GetLongestElementLength(this IEnumerable<string> source)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            var longestElementLength = 0;

            foreach (var element in source)
            {
                if (element.Length > longestElementLength)
                    longestElementLength = element.Length;
            }

            return longestElementLength;
        }
    }
}