using System;

namespace ByteDev.Cmd
{
    /// <summary>
    /// Represents prompts for keyboard input.
    /// </summary>
    public static class Prompt
    {
        /// <summary>
        /// Prompt and wait for any key press.
        /// </summary>
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");

            Keyboard.WaitForAnyKey();
        }

        /// <summary>
        /// Prompt and wait for Enter key to be pressed.
        /// </summary>
        public static void PressEnter()
        {
            Console.WriteLine("Press Enter to continue...");

            Keyboard.WaitForKey(ConsoleKey.Enter);
        }
    }
}