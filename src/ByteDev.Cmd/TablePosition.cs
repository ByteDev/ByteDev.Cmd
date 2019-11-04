using System;

namespace ByteDev.Cmd
{
    /// <summary>
    /// Represents a cell position in <see cref="T:ByteDev.Cmd.Table" />.
    /// </summary>
    public struct TablePosition
    {
        /// <summary>
        /// Position on the X axis.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Position on the Y axis.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.TablePosition" /> class.
        /// </summary>
        /// <param name="x">Position on the X axis.</param>
        /// <param name="y">Position on the Y axis.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="x" /> cannot be less than zero.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="y" /> cannot be less than zero.</exception>
        public TablePosition(int x, int y)
        {
            if (x < 0)
                throw new ArgumentOutOfRangeException(nameof(x), x, "X cannot be less than zero.");

            if (y < 0)
                throw new ArgumentOutOfRangeException(nameof(y), y, "Y cannot be less than zero.");

            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns a string representation of <see cref="T:ByteDev.Cmd.TablePosition" />.
        /// </summary>
        /// <returns>String representation of <see cref="T:ByteDev.Cmd.TablePosition" />.</returns>
        public override string ToString()
        {
            return $"{X}x{Y}";
        }
    }
}