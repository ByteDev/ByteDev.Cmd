using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteDev.Cmd.Arguments
{
    /// <summary>
    /// Represents allowed input command line arguments.
    /// </summary>
    public class CmdArgInfo
    {
        private const string ArgNamePrefix = "-";

        private readonly IList<CmdAllowedArg> _cmdAllowedArgs;
        private readonly CmdArgFactory _factory;

        private IList<CmdArg> _cmdArgs;

        /// <summary>
        /// Whether input command line arguments were provided.
        /// </summary>
        public bool HasArguments => Arguments.Count > 0;

        /// <summary>
        /// The input command line arguments that are allowed.
        /// </summary>
        public IList<CmdArg> Arguments
        {
            get => _cmdArgs ?? (_cmdArgs = new List<CmdArg>());
            set => _cmdArgs = value;
        }
        
        /// <summary>
        /// Help text for the allowed arguments.
        /// </summary>
        public string HelpText => CreateHelpText();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.Cmd.Arguments.CmdArgInfo" /> class.
        /// </summary>
        /// <param name="inputArgs">Command line arguments. Usually from the Program.Main method.</param>
        /// <param name="cmdAllowedArgs">Definitions of the allowed arguments.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="inputArgs" /> is null.</exception>
        /// <exception cref="T:ByteDev.Cmd.Arguments.CmdArgException">Provided arg is not valid.</exception>
        public CmdArgInfo(IEnumerable<string> inputArgs, IList<CmdAllowedArg> cmdAllowedArgs)
        {
            if(inputArgs == null)
                throw new ArgumentNullException(nameof(inputArgs));

            _factory = new CmdArgFactory(cmdAllowedArgs);

            _cmdAllowedArgs = cmdAllowedArgs;
            
            AddArguments(inputArgs);
        }

        private void AddArguments(IEnumerable<string> inputArgs)
        {
            string currentName = null;
            
            foreach (var inputArg in inputArgs)
            {
                if (IsArgName(inputArg))
                {
                    currentName = inputArg.Substring(1);

                    if(!_cmdAllowedArgs.GetAllowedArgOrThrow(currentName).HasValue)
                        Arguments.Add(_factory.Create(currentName));
                }
                else
                {
                    if (currentName == null)
                        ExceptionThrower.ArgValueHasNoCorrespondingName(inputArg);

                    Arguments.Add(_factory.Create(currentName, inputArg));

                    currentName = null;
                }
            }

            CheckAllRequiredArgsPresent();
        }

        private void CheckAllRequiredArgsPresent()
        {
            var sb = new StringBuilder();

            foreach (var cmdAllowedArg in _cmdAllowedArgs.Where(caa => caa.IsRequired))
            {
                if (!Arguments.Any(a => a.ShortName == cmdAllowedArg.ShortName))
                    sb.AppendLine($"Argument '{cmdAllowedArg.ShortName}' is required and not supplied.");
            }

            if (sb.Length > 0)
                throw new CmdArgException(sb.ToString().TrimEnd());
        }

        private static bool IsArgName(string arg)
        {
            return arg.Substring(0, 1) == ArgNamePrefix;
        }
        
        private string CreateHelpText()
        {
            const string delimiter = "     ";

            var longestLenName = _cmdAllowedArgs.GetLongestNameLength();

            var sb = new StringBuilder();

            foreach (var allowedArg in _cmdAllowedArgs)
            {
                sb.Append(allowedArg.PrefixedShortName);

                if (allowedArg.HasDescription)
                {
                    var padding = new string(' ', longestLenName - 1);
                    sb.Append(padding + delimiter + allowedArg.Description);
                }

                sb.AppendLine();

                if (allowedArg.HasLongName)
                {
                    sb.Append(allowedArg.PrefixedLongName);

                    if (allowedArg.HasDescription)
                    {
                        var padding = new string(' ', longestLenName - allowedArg.LongName.Length);
                        sb.Append(padding + delimiter + allowedArg.Description);
                    }

                    sb.AppendLine();
                }
            }
         
            return sb.ToString();
        }
    }
}