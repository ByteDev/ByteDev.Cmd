using System;
using ByteDev.Cmd.Lists;

namespace ByteDev.Cmd.TestApp
{
    public static class OutputTestListExtensions
    {
        public static void TestLists(this Output source)
        {
            source.WriteTestHeader("Testing Lists");

            var ul = new UnorderedList(new [] { "Item 1", "Item 2", "Item 3" })
            {
                ItemPrefix = "* ",
                ItemColor = new OutputColor(ConsoleColor.DarkBlue, ConsoleColor.Gray)
            };
            source.Write(ul);
            source.WriteLine();

            var ol = new OrderedList(new[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 10", "Item 11", "Item 12" })
            {
                ItemStartingNumber = 0,
                ItemColor = new OutputColor(ConsoleColor.Black, ConsoleColor.Yellow),
                ApplyItemNumberPadding = true
            };
            source.Write(ol);
        }
    }
}