using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ankh_Morpork
{
    internal static class EventBuilder
    {
        internal static Event CreateEvent()
        {
            var rnd = new Random();
            var randomGuildNumber = rnd.Next(0, guilds.Count);
            return new Event(guilds[randomGuildNumber].GetNpc());

            
        }

        internal static void LoadGuilds()
        {
            guilds = new List<Guild>();
            guilds.Add(new AssassinsGuild());
        }

        private static List<Guild> guilds;
    }
}
