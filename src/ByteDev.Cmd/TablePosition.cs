using System;

namespace ByteDev.Cmd
{
    /// <summary>
    /// Represents a cell position in <see cref="T:ByteDev.Cmd.Table" />.
    /// </summary>
    public struct TablePosition
    {
        /// <summary>
        /// Column number position.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Row number position.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.TablePosition" /> class.
        /// </summary>
        /// <param name="column">Column number position. First position is zero.</param>
        /// <param name="row">Row number position. First position is zero.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="column" /> cannot be less than zero.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="row" /> cannot be less than zero.</exception>
        public TablePosition(int column, int row)
        {
            if (column < 0)
                throw new ArgumentOutOfRangeException(nameof(column), column, "Column number cannot be less than zero.");

            if (row < 0)
                throw new ArgumentOutOfRangeException(nameof(row), row, "Row number cannot be less than zero.");

            Column = column;
            Row = row;
        }

        /// <summary>
        /// Returns a string representation of <see cref="T:ByteDev.Cmd.TablePosition" />.
        /// </summary>
        /// <returns>String representation of <see cref="T:ByteDev.Cmd.TablePosition" />.</returns>
        public override string ToString()
        {
            return $"{Column}x{Row}";
        }
    }
}