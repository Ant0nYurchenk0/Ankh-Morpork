using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    internal static class EventBuilder
    {
        internal readonly static Random Random = new Random();
        internal static Event CreateEvent()
        {
            _guilds = (from guild in _guilds
                      where guild.Npcs.Count > 0
                      select guild).ToList();
            var randomGuildNumber = Random.Next(0, _guilds.Count);
            var selectedGuild = _guilds[randomGuildNumber];
            return new Event(selectedGuild.GetNpc(), selectedGuild);
        }
        internal static void LoadGuilds()
        {
            _guilds = new List<Guild>();
            _guilds.Add(new AssassinsGuild(Constant.AssassinsGuild, ConsoleColor.DarkGray));
            _guilds.Add(new ThievesGuild(Constant.ThievesGuild, ConsoleColor.DarkMagenta));
            _guilds.Add(new BeggarsGuild(Constant.BeggarsGuild, ConsoleColor.DarkRed));
            _guilds.Add(new ClownsGuild(Constant.ClownsGuild, ConsoleColor.DarkYellow));
        }

        private static List<Guild> _guilds;
    }
}
