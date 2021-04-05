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
        /// The input command line arguments.
        /// </summary>
        public IList<CmdArg> Arguments
        {
            get => _cmdArgs ?? (_cmdArgs = new List<CmdArg>());
            set => _cmdArgs = value;
        }
        
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

        /// <summary>
        /// Get <see cref="T:ByteDev.Cmd.Arguments.CmdArg" /> based on it's short name.
        /// </summary>
        /// <param name="shortName">The short name of the argument.</param>
        /// <returns><see cref="T:ByteDev.Cmd.Arguments.CmdArg" /> with the short name; otherwise null.</returns>
        public CmdArg GetArgument(char shortName)
        {
            return Arguments.SingleOrDefault(a => a.ShortName == shortName);
        }

        /// <summary>
        /// Get <see cref="T:ByteDev.Cmd.Arguments.CmdArg" /> based on it's long name.
        /// </summary>
        /// <param name="longName">The long name of the argument.</param>
        /// <returns><see cref="T:ByteDev.Cmd.Arguments.CmdArg" /> with the long name; otherwise null.</returns>
        public CmdArg GetArgument(string longName)
        {
            return Arguments.SingleOrDefault(a => a.LongName == longName);
        }

        /// <summary>
        /// Indicates if the argument exists based on it's short name.
        /// </summary>
        /// <param name="shortName">The short name of the argument.</param>
        /// <returns>True if the argument exists; otherwise false.</returns>
        public bool HasArgument(char shortName)
        {
            return GetArgument(shortName) != null;
        }

        /// <summary>
        /// Indicates if the argument exists based on it's long name.
        /// </summary>
        /// <param name="longName">The long name of the argument.</param>
        /// <returns>True if the argument exists; otherwise false.</returns>
        public bool HasArgument(string longName)
        {
            return GetArgument(longName) != null;
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

            CheckNumberArgsProvided();
            CheckAllRequiredArgsPresent();
        }

        private void CheckNumberArgsProvided()
        {
            if (Arguments.Count > _cmdAllowedArgs.Count)
            {
                var argNames = string.Empty;

                foreach (var cmdArg in Arguments)
                {
                    if (argNames != string.Empty)
                        argNames += ", ";

                    argNames += cmdArg.ShortName;
                }

                throw new CmdArgException($"Allowed arguments {_cmdAllowedArgs.Count} but {Arguments.Count} provided ({argNames}).");
            }
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
    }
}