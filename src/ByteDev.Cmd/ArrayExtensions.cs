namespace ByteDev.Cmd
{
    internal static class ArrayExtensions
    {
        public static void Populate<T>(this T[,] source, T value)
        {
            for (var i = 0; i < source.GetLength(0); i++)
            {
                for (var j = 0; j < source.GetLength(1); j++)
                {
                    source[i, j] = value;
                }
            }
        }
    }
}