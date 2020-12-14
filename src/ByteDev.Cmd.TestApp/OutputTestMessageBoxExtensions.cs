using System;

namespace ByteDev.Cmd.TestApp
{
    public static class OutputTestMessageBoxExtensions
    {
        public static void TestMessageBox(this Output source)
        {
            source.WriteTestHeader("Testing MessageBox");

            var messageBox = new MessageBox("this is text in a message box\nsecond\nthird line")
            {
                BorderColor = new OutputColor(ConsoleColor.Red, ConsoleColor.Blue),
                TextColor = new OutputColor(ConsoleColor.White, ConsoleColor.Blue)
            };
            
            source.Write(messageBox);
        }
    }
}