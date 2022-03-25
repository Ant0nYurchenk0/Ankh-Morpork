using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal static class EventBuilder
    {
        internal static Event CreateEvent()
        {
            var rnd = new Random();
            var randomGuildNumber = rnd.Next(0, _guilds.Count);
            var selectedGuild = _guilds[randomGuildNumber];
            return new Event(selectedGuild.GetNpc(), selectedGuild);
        }
        internal static void LoadGuilds()
        {
            _guilds = new List<Guild>();
            _guilds.Add(new AssassinsGuild());
            _guilds.Add(new ThievesGuild());
        }

        private static List<Guild> _guilds;
    }
}
