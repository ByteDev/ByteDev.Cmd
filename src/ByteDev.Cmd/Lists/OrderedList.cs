using System.Collections.Generic;

namespace ByteDev.Cmd.Lists
{
    /// <summary>
    /// Represents an ordered list.
    /// </summary>
    public class OrderedList : BaseList
    {
        /// <summary>
        /// Starting item number prefix to use when outputting the list. Defaults to one.
        /// </summary>
        public int ItemStartingNumber { get; set; } = 1;

        /// <summary>
        /// Delimiter to use between the number and the item when outputting the list. Defaults to period + space.
        /// </summary>
        public string ItemNumberDelimiter { get; set; } = ". ";

        /// <summary>
        /// Indicates whether number padding should be applied when outputting the list. Defaults to false.
        /// Item number padding will not be applied if starting number is less than zero.
        /// </summary>
        public bool ApplyItemNumberPadding { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Lists.OrderedList" /> class.
        /// </summary>
        /// <param name="items">List items.</param>
        public OrderedList(IList<string> items) : base(items)
        {
        }

        internal string GetNumberFormatted(int counter)
        {
            if (ItemStartingNumber < 0)                 // Can't pad neg numbers.
                return counter.ToString();

            var digits = (Items.Count + ItemStartingNumber - 1).ToString().Length;

            return ApplyItemNumberPadding ? counter.ToString().PadLeft(digits, '0') : counter.ToString();
        }
    }
}