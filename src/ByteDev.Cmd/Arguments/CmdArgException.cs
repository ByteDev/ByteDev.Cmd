using System;
using System.Runtime.Serialization;

namespace ByteDev.Cmd.Arguments
{
    [Serializable]
    public class CmdArgException : Exception
    {
        public CmdArgException()
        {
        }

        public CmdArgException(string message) : base(message)
        {
        }

        public CmdArgException(string message, Exception inner) : base(message, inner)
        {
        }

        protected CmdArgException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}