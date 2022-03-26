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
            _guilds = (from guild in _guilds
                      where guild.Npcs.Count > 0
                      select guild).ToList();
            var randomGuildNumber = rnd.Next(0, _guilds.Count);
            var selectedGuild = _guilds[randomGuildNumber];
            return new Event(selectedGuild.GetNpc(), selectedGuild);
        }
        internal static void LoadGuilds()
        {
            _guilds = new List<Guild>();
            _guilds.Add(new AssassinsGuild());
            _guilds.Add(new ThievesGuild());
            _guilds.Add(new BeggarsGuild());
            _guilds.Add(new ClownsGuild());
        }

        private static List<Guild> _guilds;
    }
}
