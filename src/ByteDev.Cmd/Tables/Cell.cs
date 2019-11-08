using System;

namespace ByteDev.Cmd.Tables
{
    /// <summary>
    /// Represents a cell within a <see cref="T:ByteDev.Cmd.Tables.Table" />.
    /// </summary>
    public sealed class Cell : IEquatable<Cell>
    {
        /// <summary>
        /// Cell's value.
        /// </summary>
        public string Value { get; }
        
        /// <summary>
        /// Alignment of value to be used when output.
        /// </summary>
        public CellValueAlignment ValueAlignment { get; set; }

        /// <summary>
        /// Color information to be used for the cell.
        /// </summary>
        public OutputColor ValueColor { get; set; }

        /// <summary>
        /// Returns true if the cell has a value; otherwise returns false.
        /// </summary>
        public bool HasValue => Value != null;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Tables.Cell" /> class.
        /// </summary>
        public Cell() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Tables.Cell" /> class.
        /// </summary>
        /// <param name="value">The value to set on the cell.</param>
        public Cell(string value)
        {
            Value = value;
            ValueAlignment = CellValueAlignment.Left;
        }

        /// <summary>
        /// Returns a string representation of the <see cref="T:ByteDev.Cmd.Tables.Cell" />.
        /// </summary>
        /// <returns>String representation of the <see cref="T:ByteDev.Cmd.Tables.Cell" />.</returns>
        public override string ToString()
        {
            return Value ?? string.Empty;
        }

        /// <summary>
        /// Determines whether the specified object is equal.
        /// </summary>
        /// <param name="obj">The object to compare equality on.</param>
        /// <returns>True if <paramref name="obj" /> is equal; otherwise returns false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (ReferenceEquals(obj, this))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals(obj as Cell);
        }

        /// <summary>
        /// Determines whether the specified object is equal.
        /// </summary>
        /// <param name="other">The object to compare equality on.</param>
        /// <returns>True if <paramref name="other" /> is equal; otherwise returns false.</returns>
        public bool Equals(Cell other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(other, this))
                return true;

            return string.Equals(Value, other.Value);
        }

        /// <summary>
        /// Returns the hash code for this cell.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        internal string ToStringFormatted(int width, string leftPadding = "", string rightPadding = "")
        {
            var paddedValue = GetPaddedValue(width);

            return $"{leftPadding}{paddedValue}{rightPadding}";
        }

        private string GetPaddedValue(int width)
        {
            var value = HasValue ? Value : string.Empty;

            return ValueAlignment == CellValueAlignment.Right ? value.PadLeft(width, ' ') : value.PadRight(width, ' ');
        }
    }
}