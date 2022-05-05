using Game.Players;
using System.Collections.Generic;

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