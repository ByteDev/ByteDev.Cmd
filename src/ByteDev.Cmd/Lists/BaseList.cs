using System;
using System.Collections.Generic;

namespace ByteDev.Cmd.Lists
{
    /// <summary>
    /// Represents a list.
    /// </summary>
    public abstract class BaseList
    {
        private IList<string> _items;

        /// <summary>
        /// List items.
        /// </summary>
        public IList<string> Items => _items ?? (_items = new List<string>());

        /// <summary>
        /// Color to use when outputting each item in the list.
        /// </summary>
        public OutputColor ItemColor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Lists.BaseList" /> class.
        /// </summary>
        /// <param name="items">List items.</param>
        protected BaseList(IList<string> items)
        {
            _items = items ?? throw new ArgumentNullException(nameof(items));
        }
    }
}