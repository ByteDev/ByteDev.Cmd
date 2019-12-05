using System;
using System.Collections.Generic;
using ByteDev.Cmd.Arguments;
using ByteDev.Cmd.Lists;
using ByteDev.Cmd.Logging;
using ByteDev.Cmd.Tables;
using ByteDev.Cmd.Tables.Borders;

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
                                TestOutput();
                                break;

                            case 'm':
                                TestMessageBox();
                                break;

                            case 'l':
                                TestLogger();
                                break;

                            case 't':
                                TestTable();
                                break;

                            case 'i':
                                TestLists();
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

        private static void TestLists()
        {
            Output.WriteLine();
            Output.WriteLine("***** Testing Lists *****");
            Output.WriteLine();

            var ul = new UnorderedList(new [] { "Item 1", "Item 2", "Item 3" })
            {
                ItemPrefix = "* ",
                ItemColor = new OutputColor(ConsoleColor.DarkBlue, ConsoleColor.Gray)
            };
            Output.Write(ul);

            Output.WriteLine();

            var ol = new OrderedList(new[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 10", "Item 11", "Item 12" })
            {
                ItemStartingNumber = 0,
                ItemColor = new OutputColor(ConsoleColor.Black, ConsoleColor.Yellow),
                ApplyItemNumberPadding = true
            };
            Output.Write(ol);
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
            Output.WriteAlignToSides("Left Bit (no color)", "Right Bit (no color)");
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

        private static void TestTable()
        {
            Output.WriteLine();
            Output.WriteLine("***** Testing Table *****");
            Output.WriteLine();

            var t = new Table(1, 1, "XXX");
            Output.Write(t);
            
            var table = CreateTable();
            Output.Write(table);

            var emptyTable = CreateEmptyTable();
            Output.Write(emptyTable);

            var defaultValueTable = CreateDefaultValueTable();
            Output.Write(defaultValueTable);
        }

        private static Table CreateTable()
        {
            var table = new Table(3, 3)
            {
                BorderStyle = new BorderSimple(),
                BorderColor = new OutputColor(ConsoleColor.White, ConsoleColor.Blue),
                ValueColor = new OutputColor(ConsoleColor.White, ConsoleColor.Blue)
            };

            table.UpdateCell(new CellPosition(0, 0), new Cell("A111") { ValueColor = new OutputColor(ConsoleColor.DarkBlue, ConsoleColor.White)});

            table.UpdateCell(new CellPosition(0, 1), new Cell("B1"));
            table.UpdateCell(new CellPosition(1, 1), new Cell("B2"));
            table.UpdateCell(new CellPosition(2, 1), new Cell("B3"));

            table.UpdateCell(new CellPosition(2, 2), new Cell("C3"));
            
            return table;
        }

        private static Table CreateEmptyTable()
        {
            return new Table(3, 3)
            {
                BorderStyle = new BorderSingle(),
                BorderColor = new OutputColor(ConsoleColor.White, ConsoleColor.Red),
                ValueColor = new OutputColor(ConsoleColor.White, ConsoleColor.Red)
            };
        }

        private static Table CreateDefaultValueTable()
        {
            return new Table(3, 4, "AAAAA")
            {
                BorderStyle = new BorderDouble(),
                BorderColor = new OutputColor(ConsoleColor.White, ConsoleColor.DarkGray),
                ValueColor = new OutputColor(ConsoleColor.White, ConsoleColor.DarkGray)
            };
        }
    }
}
