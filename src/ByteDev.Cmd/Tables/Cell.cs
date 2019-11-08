using System;

namespace ByteDev.Cmd.Tables
{
    public sealed class Cell : IEquatable<Cell>
    {
        public string Value { get; }
        
        public CellValueAlignment ValueAlignment { get; set; }

        /// <summary>
        /// Color information to be used for the cell.
        /// If null the value color .
        /// </summary>
        public OutputColor ValueColor { get; set; }

        public bool HasValue => Value != null;

        public Cell() : this(null)
        {
        }

        public Cell(string value)
        {
            Value = value;
            ValueAlignment = CellValueAlignment.Left;
        }

        public override string ToString()
        {
            return Value ?? string.Empty;
        }

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

        public bool Equals(Cell other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(other, this))
                return true;

            return string.Equals(Value, other.Value);
        }
        
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