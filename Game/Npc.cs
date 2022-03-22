using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal abstract class Npc
    {
        internal readonly string Name;
        internal readonly string Message;
        internal Npc(string name, string message)
        {
            Name = name;
            Message = message;
        }
        internal abstract void Accept(Player player);
        internal virtual void Deny(Player player)
        {
            player.IsAlive = false;
            Console.WriteLine("Player died");
        }
    }
}
