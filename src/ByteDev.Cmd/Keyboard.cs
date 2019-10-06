using System;

namespace ByteDev.Cmd
{
    public class Keyboard
    {
        public static void WaitForAnyKey()
        {
            while (!Console.KeyAvailable)
            {
            }

            Console.ReadKey(true);  // Don't display the input key
        }

        public static void WaitForKey(ConsoleKey key)
        {
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == key))
            {
            }
        }
    }
}