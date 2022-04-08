using System;
using System.Collections.Generic;
using Game.Npcs;

namespace Game.Guilds
{
    public interface IGuild
    {
        ConsoleColor Color { get; }
        string Description { get; }
        string Name { get; }
        List<Npc> Npcs { get; }
        Npc GetNpc();
    }
}