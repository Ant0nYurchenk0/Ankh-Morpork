using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal static class Controller
    {
        private static Player player; 
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
            var player = new Player();
            var i = 5;
            while (player.IsAlive)
            {
                var newEvent = EventBuilder.CreateEvent();
                View.DisplayEvent(newEvent);
                var responce = View.ReadResponce();
                switch (responce)
                {
                    case "1":
                        newEvent.Npc.Accept(player);
                        break;
                    case "2":
                        newEvent.Npc.Deny(player);
                        break;
                    case "3":
                        View.Help(newEvent);
                        break;
                    case "q":
                        Run();
                        break;
                }
            }
            View.GameOver();
            Run();
        }
        internal static void Init()
        {
            Config.ConfigPath = @"Config.json";
            Config.LoadConfig();
            player = new Player();
            EventBuilder.LoadGuilds();
        }

    }
}
