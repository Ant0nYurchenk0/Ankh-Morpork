using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ankh_Morpork
{
    internal static class Controller
    {
        internal static void Run()
        { 
            goToMenu();
            play();
        }
        private static void goToMenu()
        {

        }
        private static void play()
        {
            var i = 5;
            while (i-- > 0)
            {
                Console.Clear();
                var newEvent = EventBuilder.CreateEvent();
                View.DisplayEvent(newEvent);
                var responce = View.ReadResponce();
                if (responce == "q")
                    Run();
                Console.WriteLine($"Your responce is {responce}");
                Console.WriteLine("Press any key to proceed");
                Console.ReadKey();
            }
        }
        internal static void Init()
        {
            EventBuilder.LoadGuilds();
        }
    }
}
