namespace ByteDev.Cmd.Tables.Borders
{
    /// <summary>
    /// Represents a single line border style.
    /// </summary>
    public class BorderSingle : IBorderStyle
    {
        /// <summary>
        /// Character for horizontal line.
        /// </summary>
        public char HorizontalLine => '─';

        /// <summary>
        /// Character for vertical line.
        /// </summary>
        public char VerticalLine => '│';

        /// <summary>
        /// Character for left top corner.
        /// </summary>
        public char LeftTop => '┌';

        /// <summary>
        /// Character for right top corner.
        /// </summary>
        public char RightTop => '┐';

        /// <summary>
        /// Character for left bottom corner.
        /// </summary>
        public char LeftBottom => '└';

        /// <summary>
        /// Character for right bottom corner.
        /// </summary>
        public char RightBottom => '┘';
    }
}