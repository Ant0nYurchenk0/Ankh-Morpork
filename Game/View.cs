using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ankh_Morpork
{
    internal static class View
    {
        internal static void DisplayEvent(Event _event)
        {
            Console.WriteLine($"New Event! \n\t {_event.Npc.Name}");
        }
        internal static string ReadResponce()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nWrite your respone: ");
            Console.ResetColor();
            return Console.ReadLine();
        }
    }
}
