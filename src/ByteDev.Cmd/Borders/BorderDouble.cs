namespace ByteDev.Cmd.Borders
{
    /// <summary>
    /// Represents a double line border style.
    /// </summary>
    public class BorderDouble : IBorderStyle
    {
        /// <summary>
        /// Character for horizontal line.
        /// </summary>
        public char HorizontalLine => '═';

        /// <summary>
        /// Character for vertical line.
        /// </summary>
        public char VerticalLine => '║';

        /// <summary>
        /// Character for left top corner.
        /// </summary>
        public char LeftTop => '╔';

        /// <summary>
        /// Character for right top corner.
        /// </summary>
        public char RightTop => '╗';

        /// <summary>
        /// Character for left bottom corner.
        /// </summary>
        public char LeftBottom => '╚';

        /// <summary>
        /// Character for right bottom corner.
        /// </summary>
        public char RightBottom => '╝';
    }
}