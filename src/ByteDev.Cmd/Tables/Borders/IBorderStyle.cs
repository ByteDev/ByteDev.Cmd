namespace ByteDev.Cmd.Tables.Borders
{
    /// <summary>
    /// Represents a style of border to use when writing output.
    /// </summary>
    public interface IBorderStyle
    {
        /// <summary>
        /// Character for horizontal line.
        /// </summary>
        char HorizontalLine { get; }

        /// <summary>
        /// Character for vertical line.
        /// </summary>
        char VerticalLine { get; }

        /// <summary>
        /// Character for left top corner.
        /// </summary>
        char LeftTop { get; }

        /// <summary>
        /// Character for right top corner.
        /// </summary>
        char RightTop { get; }

        /// <summary>
        /// Character for left bottom corner.
        /// </summary>
        char LeftBottom { get; }

        /// <summary>
        /// Character for right bottom corner.
        /// </summary>
        char RightBottom { get; }
    }
}