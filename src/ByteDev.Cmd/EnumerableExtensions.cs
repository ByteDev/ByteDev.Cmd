using System;
using System.Collections.Generic;

namespace ByteDev.Cmd
{
    internal static class EnumerableExtensions
    {
        public static string GetLongestElement(this IEnumerable<string> source)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            string longestElement = null;

            foreach (var element in source)
            {
                if (longestElement == null || element.Length > longestElement.Length)
                    longestElement = element;
            }

            return longestElement;
        }
    }
}