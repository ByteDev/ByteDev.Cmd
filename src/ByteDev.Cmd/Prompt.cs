using System;

namespace ByteDev.Cmd
{
    public static class Prompt
    {
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");

            Keyboard.WaitForAnyKey();
        }

        public static void PressEnter()
        {
            Console.WriteLine("Press Enter to continue...");

            Keyboard.WaitForKey(ConsoleKey.Enter);
        }
    }
}