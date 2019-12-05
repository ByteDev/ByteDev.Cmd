using System.Collections.Generic;

namespace ByteDev.Cmd.Lists
{
    /// <summary>
    /// Represents an unordered list.
    /// </summary>
    public class UnorderedList : BaseList
    {
        /// <summary>
        /// Prefix character to use when outputting the list. Defaults to hyphen + space.
        /// </summary>
        public string ItemPrefix { get; set; } = "- ";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Lists.UnorderedList" /> class.
        /// </summary>
        /// <param name="items">List items.</param>
        public UnorderedList(IList<string> items) : base(items)
        {
        }
    }
}