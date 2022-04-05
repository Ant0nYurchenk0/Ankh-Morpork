using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public static class EventBuilder
    {
        private static List<Guild> _guilds { get;  set; }
        public readonly static Random Random = new Random();
        public static Event CreateEvent()
        {
            _guilds = _guilds.Where(g => g.IsActive).ToList();
            var randomGuildNumber = Random.Next(0, _guilds.Count);
            var selectedGuild = _guilds[randomGuildNumber];
            return new Event(selectedGuild.GetNpc(), selectedGuild);
        }

        public static void LoadGuilds()
        {
            _guilds = new List<Guild>();
            _guilds.Add(new AssassinsGuild(Constant.AssassinsGuild, ConsoleColor.DarkGray));
            _guilds.Add(new ThievesGuild(Constant.ThievesGuild, ConsoleColor.DarkMagenta));
            _guilds.Add(new BeggarsGuild(Constant.BeggarsGuild, ConsoleColor.DarkRed));
            _guilds.Add(new ClownsGuild(Constant.ClownsGuild, ConsoleColor.DarkYellow));
        }

    }
}
