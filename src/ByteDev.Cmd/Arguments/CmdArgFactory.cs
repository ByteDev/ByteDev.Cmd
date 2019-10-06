using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDev.Cmd.Arguments
{
    internal class CmdArgFactory
    {
        private readonly IEnumerable<CmdAllowedArg> _cmdAllowedArgs;

        public CmdArgFactory(IEnumerable<CmdAllowedArg> cmdAllowedArgs)
        {
            _cmdAllowedArgs = cmdAllowedArgs ?? throw new ArgumentNullException(nameof(cmdAllowedArgs));
        }

        public CmdArg Create(char name, string value = null)
        {
            return Create(name.ToString(), value);
        }

        public CmdArg Create(string name, string value = null)
        {
            var allowedArg = _cmdAllowedArgs.SingleOrDefault(a => a.ShortName.ToString() == name || a.LongName == name);

            if (allowedArg == null)
                ExceptionThrower.ArgNameNotAllowed(name);

            return new CmdArg
            {
                ShortName = allowedArg.ShortName,
                Value = allowedArg.HasValue ? value : null,
                LongName = allowedArg.LongName,
                Description = allowedArg.Description
            };
        }
    }
}