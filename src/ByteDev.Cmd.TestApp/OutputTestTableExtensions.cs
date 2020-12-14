using System;
using ByteDev.Cmd.Tables;
using ByteDev.Cmd.Tables.Borders;

namespace ByteDev.Cmd.TestApp
{
    public static class OutputTestTableExtensions
    {
        public static void TestTable(this Output source)
        {
            source.WriteTestHeader("Testing Table");

            var t = new Table(1, 1, "XXX");
            source.Write(t);
            
            var table = CreateTable();
            source.Write(table);

            var emptyTable = CreateEmptyTable();
            source.Write(emptyTable);

            var defaultValueTable = CreateDefaultValueTable();
            source.Write(defaultValueTable);
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