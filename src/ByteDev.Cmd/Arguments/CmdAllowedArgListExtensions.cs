﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteDev.Cmd.Arguments
{
    /// <summary>
    /// Provides extension methods for lists of <see cref="T:ByteDev.Cmd.Arguments.CmdAllowedArg" />.
    /// </summary>
    public static class CmdAllowedArgListExtensions
    {
        /// <summary>
        /// Creates a string of help text based on the list of <see cref="T:ByteDev.Cmd.Arguments.CmdAllowedArg" />.
        /// </summary>
        /// <param name="source">The list to create the help text from.</param>
        /// <returns>The help text for the list.</returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="source" /> is null.</exception>
        public static string HelpText(this IList<CmdAllowedArg> source)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

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
                if (allowedArg.HasLongName && allowedArg.LongName.Length > len)
                    len = allowedArg.LongName.Length;
            }

            return len;
        }
    }
}