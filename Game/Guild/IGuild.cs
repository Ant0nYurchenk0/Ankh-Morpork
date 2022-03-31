using System;
using System.Collections.Generic;

namespace Game
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