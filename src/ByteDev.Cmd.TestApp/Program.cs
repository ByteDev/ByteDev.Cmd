﻿using System;
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
                new CmdAllowedArg('l', false) {LongName = "logger", Description = "Test logger"}
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
                                TestOutput();
                                break;

                            case 'm':
                                TestMessageBox();
                                break;

                            case 'l':
                                TestLogger();
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

        private static void TestOutput()
        {
            Output.WriteLine();
            Output.WriteLine("***** Testing Output *****");
            Output.WriteLine();

            Output.WriteLine("Default colored text");
            Output.WriteLine();

            Output.WriteRainbowLine("Crazy rainbow message");
            Output.WriteLine();

            Output.WriteLine("Writing default horizontal line...");
            Output.WriteHorizontalLine();
            Output.WriteLine();

            Output.WriteLine("Writing color block horizontal line...");
            Output.WriteHorizontalLine('=', new OutputColor(ConsoleColor.White, ConsoleColor.Gray)); 
            Output.WriteLine();

            Output.WriteAlignLeft("Aligned Left", new OutputColor(ConsoleColor.White, ConsoleColor.Red));
            Output.WriteAlignRight("Aligned Right", new OutputColor(ConsoleColor.White, ConsoleColor.DarkGreen));
            Output.WriteAlignCenter("Aligned Center", new OutputColor(ConsoleColor.White, ConsoleColor.Blue));
            Output.WriteAlignToSides("Left Bit", "Right Bit", new OutputColor(ConsoleColor.Black, ConsoleColor.Gray));
            Output.WriteLine();

            Output.WriteAlignLeft("Aligned Left (no color)");
            Output.WriteAlignRight("Aligned Right (no color)");
            Output.WriteAlignCenter("Aligned Center (no color)");
            Output.WriteAlignToSides("Left Bit (no color)", "Right Bit (no color)", new OutputColor(ConsoleColor.Black, ConsoleColor.Gray));
            Output.WriteLine();

            Output.WriteLine("Writing 3 blank lines...");
            Output.WriteBlankLines(3);

            Output.WriteLine("Default colored text");
        }

        private static void TestMessageBox()
        {
            Output.WriteLine();
            Output.WriteLine("***** Testing MessageBox *****");
            Output.WriteLine();

            var messageBox = new MessageBox("this is text in a message box\nsecond\nthird line")
            {
                BorderColor = new OutputColor(ConsoleColor.Red, ConsoleColor.Blue),
                TextColor = new OutputColor(ConsoleColor.White, ConsoleColor.Blue)
            };
            
            Output.Write(messageBox);
        }

        private static void TestLogger()
        {
            Output.WriteLine();
            Output.WriteLine("***** Testing Logger *****");
            Output.WriteLine();

            var logger = new Logger(LogLevel.Debug);

            logger.WriteDebug("Debug message");
            logger.WriteInfo("Info message");
            logger.WriteWarning("Warning message");
            logger.WriteError("Error message");
            logger.WriteCritical("Critical message");
        }
    }
}
