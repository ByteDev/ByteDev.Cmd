using System;

namespace ByteDev.Cmd
{
    public struct TablePosition
    {
        public int X { get; }

        public int Y { get; }

        public TablePosition(int x, int y)
        {
            if (x < 0)
                throw new ArgumentOutOfRangeException(nameof(x), x, "X cannot be less than zero.");

            if (y < 0)
                throw new ArgumentOutOfRangeException(nameof(y), y, "Y cannot be less than zero.");

            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X}x{Y}";
        }
    }
}