using System;
using System.Text;

namespace ByteDev.Cmd
{
    public class Table
    {
        private readonly string[,] _cells;

        private OutputColor _borderColor;
        private OutputColor _valueColor;

        public int Columns { get; }

        public int Rows { get; }

        public string LeftPadding { get; set; } = " ";

        public string RightPadding { get; set; } = " ";

        /// <summary>
        /// Color of the table border.
        /// </summary>
        public OutputColor BorderColor
        {
            get => _borderColor;
            set => _borderColor = value ?? ConsoleEx.GetColor();
        }
        
        /// <summary>
        /// Color of each value inside the table.
        /// </summary>
        public OutputColor ValueColor
        {
            get => _valueColor;
            set => _valueColor = value ?? ConsoleEx.GetColor();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Table" /> class.
        /// </summary>
        /// <param name="columns">Number of columns.</param>
        /// <param name="rows">Number of rows.</param>
        /// <param name="defaultValue">A default value to be populated in each cell of the table.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="columns" /> cannot be less than one.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rows" /> cannot be less than one.</exception>
        public Table(int columns, int rows, string defaultValue = null)
        {
            if (columns < 1)
                throw new ArgumentOutOfRangeException(nameof(columns), columns, "Columns cannot be less than one.");

            if (rows < 1)
                throw new ArgumentOutOfRangeException(nameof(rows), rows, "Rows cannot be less than one.");

            _cells = new string[columns, rows];

            Columns = columns;
            Rows = rows;

            if (!string.IsNullOrEmpty(defaultValue))
                _cells.Populate(defaultValue);
        }
        
        public string GetValue(TablePosition position)
        {
            try
            {
                return _cells[position.X, position.Y];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"Cannot retrieve value at position {position}. Position is outside the bounds of the table.", ex);
            }
        }

        public void InsertValue(TablePosition position, string value)
        {
            try
            {
                _cells[position.X, position.Y] = value;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"Cannot insert value into position {position}. Position is outside the bounds of the table.", ex);
            }
        }

        internal string GetLine(int rowPosition)
        {
            if(rowPosition < 0 || rowPosition > Rows - 1)
                throw new ArgumentOutOfRangeException(nameof(rowPosition), $"No row exists at position {rowPosition}.");

            var longestLength = GetLongestValueLength();

            var sb = new StringBuilder();

            for (var colPosition = 0; colPosition < Columns; colPosition++)
            {
                var value = _cells[colPosition, rowPosition] ?? string.Empty;

                value = value.PadLeft(longestLength, ' ');

                sb.Append($"{LeftPadding}{value}{RightPadding}");
            }

            return sb.ToString();
        }

        internal int GetLongestValueLength()
        {
            int length = 0;

            foreach (var cell in _cells)
            {
                if (cell != null && cell.Length > length)
                    length = cell.Length;
            }

            return length;
        }
    }
}