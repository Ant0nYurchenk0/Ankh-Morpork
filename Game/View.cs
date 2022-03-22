using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal static class View
    {
        internal static void DisplayEvent(Event _event)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"New Event!");
            Console.ResetColor();
            Console.WriteLine($"{_event.Npc.Name} of {_event.Guild.Name}:\n\t{_event.Npc.Message}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t1.Accept\n\t2.Deny\n\t3.Wait, what?");
            Console.ResetColor();
        }
        internal static void Help(Event _event)
        {
            Console.Clear();
            Console.WriteLine($"{_event.Guild.Description}");
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
            DisplayEvent(_event);
        }
        internal static string ReadResponce()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nWrite your respone: ");
            Console.ResetColor();
            return Console.ReadLine();
        }
        internal static void GameOver()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over");
            Console.ResetColor();
            Console.WriteLine("Press any key to go to main menu");
            Console.ReadKey();
        }
    }
}
