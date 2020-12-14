using System;
using System.Collections.Generic;
using ByteDev.Cmd.Arguments;
using ByteDev.Cmd.Logging;

namespace ByteDev.Cmd.TestApp
{
    internal class Program
    {
        private static Output Output => new Output();

        private static void Main(string[] args)
        {
            Output.WriteLine("ByteDev.Cmd.TestApp", new OutputColor(ConsoleColor.White, ConsoleColor.Blue));
            Output.WriteLine();

            var cmdAllowedArgs = new List<CmdAllowedArg>
            {
                new CmdAllowedArg('o', false) {LongName = "output", Description = "Test output"},
                new CmdAllowedArg('m', false) {LongName = "messagebox", Description = "Test message box"},
                new CmdAllowedArg('l', false) {LongName = "logger", Description = "Test logger"},
                new CmdAllowedArg('t', false) {LongName = "table", Description = "Test table"},
                new CmdAllowedArg('i', false) {LongName = "lists", Description = "Test Lists"}
            };

            try
            {
                var cmdArgInfo = new CmdArgInfo(args, cmdAllowedArgs);

                if (cmdArgInfo.HasArguments)
                {
                    foreach (var cmdArg in cmdArgInfo.Arguments)
                    {
                        switch (cmdArg.ShortName)
                        {
                            case 'o':
                                Output.TestOutput();
                                break;

                            case 'm':
                                Output.TestMessageBox();
                                break;

                            case 'l':
                                TestLogger();
                                break;

                            case 't':
                                Output.TestTable();
                                break;

                            case 'i':
                                Output.TestLists();
                                break;
                        }
                    }
                }
                else
                {
                    Output.WriteLine(cmdAllowedArgs.HelpText());
                }
            }
            catch (CmdArgException ex)
            {
                Output.WriteLine(ex.Message, new OutputColor(ConsoleColor.Red));
                Output.WriteLine(cmdAllowedArgs.HelpText());
            }
            
            Prompt.PressAnyKey();
        }

        private static void TestLogger()
        {
            Output.WriteTestHeader("Testing Logger");

            var logger = new Logger(LogLevel.Debug);

            logger.WriteDebug("Debug message");
            logger.WriteInfo("Info message");
            logger.WriteWarning("Warning message");
            logger.WriteError("Error message");
            logger.WriteCritical("Critical message");
        }
    }
}
