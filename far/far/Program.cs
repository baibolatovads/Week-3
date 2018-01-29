using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace far
{
    class Program
    {
        static void Main(string[] args)
        {

            //Environment.GetLogicalDrives();
            Console.SetWindowSize(40, 40);
            FAR far = new FAR(@"C:\Users\User_PC\Documents\PP2");

            bool quit = false;

            while (!quit)
            {
                far.Draw();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Enter:
                        far.Process(pressedKey);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
