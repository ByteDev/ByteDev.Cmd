using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteDev.Cmd.Arguments
{
    public static class CmdAllowedArgsListExtensions
    {
        public static string HelpText(this IList<CmdAllowedArg> source)
        {
            int lenLongestName = source.GetLongestNameLength();

            var sb = new StringBuilder();

            foreach (var allowedArg in source)
            {
                sb.Append(allowedArg.CreateHelpText(lenLongestName));
            }

            return sb.ToString();
        }

        internal static CmdAllowedArg GetAllowedArgOrThrow(this IList<CmdAllowedArg> source, string name)
        {
            var cmdAllowedArg = source.SingleOrDefault(a => a.ShortName.ToString() == name || a.LongName == name);

            if (cmdAllowedArg == null)
                ExceptionThrower.ArgNameNotAllowed(name);

            return cmdAllowedArg;
        }

        internal static int GetLongestNameLength(this IList<CmdAllowedArg> source)
        {
            var len = 1;        // because short name is always len 1

            foreach (var allowedArg in source)
            {
                if (allowedArg.LongName != null && allowedArg.LongName.Length > len)
                    len = allowedArg.LongName.Length;
            }

            return len;
        }
    }
}