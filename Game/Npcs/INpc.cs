using System.Collections.Generic;
using Game.Players;

namespace Game.Npcs
{
    public interface INpc
    {
        Dictionary<string, string> Messages { get; set; }
        string Name { get; set; }
        void Accept(IPlayer player);
        void Deny(IPlayer player);
    }
}