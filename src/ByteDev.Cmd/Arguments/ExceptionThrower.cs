namespace ByteDev.Cmd.Arguments
{
    internal static class ExceptionThrower
    {
        public static void ArgNameNotAllowed(string name)
        {
            throw new CmdArgException($"Argument name: '{name}' is not allowed.");
        }

        public static void ArgValueHasNoCorrespondingName(string inputArg)
        {
            throw new CmdArgException($"Argument value: '{inputArg}' has no corresponding name.");
        }
    }
}