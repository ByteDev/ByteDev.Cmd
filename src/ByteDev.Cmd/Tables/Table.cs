using System;
using ByteDev.Cmd.Tables.Borders;

namespace ByteDev.Cmd.Tables
{
    /// <summary>
    /// Represents a console table.
    /// </summary>
    public class Table
    {
        private readonly Cell[,] _cells;

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
        /// Default color information for each <see cref="T:ByteDev.Cmd.Tables.Cell" /> inside the table.
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

            _cells = new Cell[columns, rows];

            if (defaultValue != null)
                _cells.Populate(new Cell(defaultValue));
        }

        /// <summary>
        /// Return a cell value based on its position.
        /// </summary>
        /// <param name="position">The position of the cell in the table.</param>
        /// <returns>The value at the <paramref name="position" />.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> is outside the bounds of the table.</exception>
        public Cell GetCell(CellPosition position)
        {
            try
            {
                return _cells[position.Column, position.Row];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"Cannot retrieve cell at position {position}. Position is outside the bounds of the table.", ex);
            }
        }

        /// <summary>
        /// Update a cell's value at a certain position in the table.
        /// </summary>
        /// <param name="position">The position of the cell in the table.</param>
        /// <param name="cell">The cell to update with.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> is outside the bounds of the table.</exception>
        public void UpdateCell(CellPosition position, Cell cell)
        {
            try
            {
                _cells[position.Column, position.Row] = cell;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"Cannot update cell at position {position}. Position is outside the bounds of the table.", ex);
            }
        }

        /// <summary>
        /// Update all the cells on a particular row.
        /// </summary>
        /// <param name="rowNumber">The row number to update.</param>
        /// <param name="cells">The cells to update the row with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="cells" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rowNumber" /> is outside the bounds of the table.</exception>
        public void UpdateRow(int rowNumber, Cell[] cells)
        {
            UpdateRow(new CellPosition(0, rowNumber), cells);
        }

        /// <summary>
        /// Update all the cell values on a particular row.
        /// </summary>
        /// <param name="position">The position of the first cell to update on the row.</param>
        /// <param name="cells">The cells to update the row with.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="cells" /> is null.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="position" /> is outside the bounds of the table.</exception>
        public void UpdateRow(CellPosition position, Cell[] cells)
        {
            if(cells == null)
                throw new ArgumentNullException(nameof(cells));

            if(position.Column >= Columns)
                throw new ArgumentOutOfRangeException($"Cannot update cell at row {position}. Position is outside the bounds of the table.");

            var col = position.Column;
            var cellIndex = 0;

            try
            {
                while (col < Columns)
                {
                    if (cellIndex >= cells.Length)
                        return;

                    _cells[col, position.Row] = cells[cellIndex];

                    col++;
                    cellIndex++;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"Cannot update cell at row {col}x{position.Row}. Position is outside the bounds of the table.", ex);
            }
        }

        /// <summary>
        /// Returns an entire table row.
        /// </summary>
        /// <param name="rowNumber">The number of the row to return. First row is number zero.</param>
        /// <returns>Row at <paramref name="rowNumber" />.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="rowNumber" /> is outside the bounds of the table.</exception>
        public Cell[] GetRow(int rowNumber)
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
        public Cell[] GetColumn(int columnNumber)
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

        internal int GetLongestCellValueLength()
        {
            var length = 0;

            foreach (var cell in _cells)
            {
                if (cell != null && cell.Value.Length > length)
                    length = cell.Value.Length;
            }

            return length;
        }
    }
}