using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Cmd.Arguments
{
    internal static class ListCmdAllowedArgsExtensions
    {
        public static CmdAllowedArg GetAllowedArgOrThrow(this IList<CmdAllowedArg> source, string name)
        {
            var cmdAllowedArg = source.SingleOrDefault(a => a.ShortName.ToString() == name || a.LongName == name);

            if (cmdAllowedArg == null)
                ExceptionThrower.ArgNameNotAllowed(name);

            return cmdAllowedArg;
        }

        public static int GetLongestNameLength(this IList<CmdAllowedArg> source)
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