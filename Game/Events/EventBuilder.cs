using Game.Constants;
using Game.Guilds;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Game.Events
{
    public static class EventBuilder
    {
        public static List<Guild> Guilds { get; private set; }
        public readonly static Random Random = new Random();
        public static Event CreateEvent()
        {
            Guilds = Guilds.Where(g => g.IsActive).ToList();
            var randomGuildNumber = Random.Next(0, Guilds.Count);
            var selectedGuild = Guilds[randomGuildNumber];
            return new Event(selectedGuild.GetNpc(), selectedGuild);
        }

        public static void LoadGuilds()
        {
            Guilds = new List<Guild>
            {
                new AssassinsGuild(Constant.AssassinsGuild, ConsoleColor.DarkGray),
                new ThievesGuild(Constant.ThievesGuild, ConsoleColor.DarkMagenta),
                new BeggarsGuild(Constant.BeggarsGuild, ConsoleColor.DarkRed),
                new ClownsGuild(Constant.ClownsGuild, ConsoleColor.DarkYellow)
            };
        }

    }
}
