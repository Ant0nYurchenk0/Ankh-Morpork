using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal abstract class Guild
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public List<Npc> Npcs { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        internal Guild()
        {
            LoadData();
            Npcs = new List<Npc>();
            LoadNpcs();
        }
        internal virtual Npc GetNpc()
        {
            var rnd = new Random();
            var randomNpcNumber = rnd.Next(0, Npcs.Count);
            return Npcs[randomNpcNumber];
        }

        protected abstract void LoadNpcs();
        protected abstract void LoadData();
    }
}
