namespace ByteDev.Cmd
{
    internal static class WrapStringExtensions
    {
        public static string SanitizeWord(this string word)
        {
            return word
                .Replace("\n", string.Empty)
                .Replace("\r", string.Empty);
        }

        public static int GetWordLength(this string word)
        {
            int len = word.Length;

            if (word.Contains("\n") || word.Contains("\r"))
                len--;

            return len;
        }
    }
}