using System;

namespace ByteDev.Cmd
{
    /// <summary>
    /// Represents console keyboard.
    /// </summary>
    public class Keyboard
    {
        /// <summary>
        /// Wait for any key to be pressed. The pressed key will not be written to the console.
        /// </summary>
        public static void WaitForAnyKey()
        {
            while (!Console.KeyAvailable)
            {
            }

            Console.ReadKey(true);  // Don't display the input key
        }

        /// <summary>
        /// Wait for a specified key to be pressed. The pressed key will not be written to the console.
        /// </summary>
        /// <param name="key">The key to wait for.</param>
        public static void WaitForKey(ConsoleKey key)
        {
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == key))
            {
            }
        }
    }
}