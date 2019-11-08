using System;
using System.Text;
using ByteDev.Cmd.Tables.Borders;

namespace ByteDev.Cmd.Tables
{
    /// <summary>
    /// Represents a console table.
    /// </summary>
    public class Table
    {
        private readonly string[,] _cells;

        private IBorderStyle _borderStyle;
        private OutputColor _borderColor;
        private OutputColor _valueColor;

        /// <summary>
        /// Number of columns.
        /// </summary>
        public int Columns => _cells.GetColumnCount();

        /// <summary>
        /// Number of rows.
        /// </summary>
        public int Rows => _cells.GetRowCount();
        
        /// <summary>
        /// Padding to apply to the left of each table cell.
        /// </summary>
        public string LeftPadding { get; set; } = " ";

        /// <summary>
        /// Padding to apply to the right of each table cell.
        /// </summary>
        public string RightPadding { get; set; } = " ";

        /// <summary>
        /// Border style.
        /// </summary>
        public IBorderStyle BorderStyle
        {
            get => _borderStyle ?? (_borderStyle = new BorderDouble());
            set => _borderStyle = value;
        }

        /// <summary>
        /// Color of the table border.
        /// </summary>
        public OutputColor BorderColor
        {
            get => _borderColor ?? (_borderColor = ConsoleEx.GetColor());
            set => _borderColor = value;
        }
        
        /// <summary>
        /// Color of each cell value inside the table.
        /// </summary>
        public OutputColor ValueColor
        {
            get => _valueColor ?? (_valueColor = ConsoleEx.GetColor());
            set => _valueColor = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Tables.Table" /> class.
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

            if (!string.IsNullOrEmpty(defaultValue))
                _cells.Populate(defaultValue);
        }

        /// <summary>
        /// Return a cell value based on its position.
        /// </summary>
        /// <param name="position">The position of the cell in the table.</param>
        /// <returns>The value at the <paramref name="position" />.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> is outside the bounds of the table.</exception>
        public string GetCell(CellPosition position)
        {
            try
            {
                return _cells[position.Column, position.Row];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"Cannot retrieve cell value at position {position}. Position is outside the bounds of the table.", ex);
            }
        }

        /// <summary>
        /// Update a cell's value at a certain position in the table.
        /// </summary>
        /// <param name="position">The position of the cell in the table.</param>
        /// <param name="value">The value to update with.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> is outside the bounds of the table.</exception>
        public void UpdateCell(CellPosition position, string value)
        {
            try
            {
                _cells[position.Column, position.Row] = value;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"Cannot update value at position {position}. Position is outside the bounds of the table.", ex);
            }
        }

        /// <summary>
        /// Update all the cell values on a particular row.
        /// </summary>
        /// <param name="rowNumber">The row to update on the row.</param>
        /// <param name="values">The values to update the row with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="values" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rowNumber" /> is outside the bounds of the table.</exception>
        public void UpdateRow(int rowNumber, string[] values)
        {
            UpdateRow(new CellPosition(0, rowNumber), values);
        }

        /// <summary>
        /// Update all the cell values on a particular row.
        /// </summary>
        /// <param name="position">The position of the first cell to update on the row.</param>
        /// <param name="values">The values to update the row with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="values" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> is outside the bounds of the table.</exception>
        public void UpdateRow(CellPosition position, string[] values)
        {
            if(values == null)
                throw new ArgumentNullException(nameof(values));

            if(position.Column >= Columns)
                throw new ArgumentOutOfRangeException($"Cannot update value at row {position}. Position is outside the bounds of the table.");

            var col = position.Column;
            var valuesIndex = 0;

            try
            {
                while (col < Columns)
                {
                    if (valuesIndex >= values.Length)
                        return;

                    _cells[col, position.Row] = values[valuesIndex];

                    col++;
                    valuesIndex++;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"Cannot update value at row {col}x{position.Row}. Position is outside the bounds of the table.", ex);
            }
        }

        /// <summary>
        /// Returns an entire table row.
        /// </summary>
        /// <param name="rowNumber">The number of the row to return. First row is number zero.</param>
        /// <returns>Row at <paramref name="rowNumber" />.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rowNumber" /> is outside the bounds of the table.</exception>
        public string[] GetRow(int rowNumber)
        {
            try
            {
                return _cells.GetRow(rowNumber);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"No row exists at number: {rowNumber}. Position is outside the bounds of the table.", ex);
            }
        }

        /// <summary>
        /// Returns an entire table column.
        /// </summary>
        /// <param name="columnNumber">The number of the column to return. First column is number zero.</param>
        /// <returns>Column at <paramref name="columnNumber" />.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="columnNumber" /> is outside the bounds of the table.</exception>
        public string[] GetColumn(int columnNumber)
        {
            try
            {
                return _cells.GetColumn(columnNumber);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"No column exists at number: {columnNumber}. Position is outside the bounds of the table.", ex);
            }
        }

        internal string GetRowText(int rowNumber)
        {
            if(rowNumber < 0 || rowNumber > Rows - 1)
                throw new ArgumentOutOfRangeException(nameof(rowNumber), $"No row exists at position {rowNumber}.");

            var longestLength = GetLongestElementLength();

            var sb = new StringBuilder();

            for (var colPosition = 0; colPosition < Columns; colPosition++)
            {
                var value = _cells[colPosition, rowNumber] ?? string.Empty;

                value = value.PadLeft(longestLength, ' ');

                sb.Append($"{LeftPadding}{value}{RightPadding}");
            }

            return sb.ToString();
        }

        internal int GetLongestElementLength()
        {
            var length = 0;

            foreach (var cell in _cells)
            {
                if (cell != null && cell.Length > length)
                    length = cell.Length;
            }

            return length;
        }
    }
}