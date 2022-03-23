using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal abstract class Guild
    {
        internal Guild()
        {
            faculty = new List<Npc>();
            loadNpcs();
            if (faculty.Count == 0)
                throw new DllNotFoundException("Error: Source file absent or damaged");
            loadData();
        }
        internal string Name { get => name;}
        internal string Description { get => description;}
        internal List<Npc> Faculty { get => faculty;}

        protected string name;
        protected string description;
        protected List<Npc> faculty;
        internal abstract Npc GetNpc();
        protected abstract void loadNpcs();
        protected abstract void loadData();
    }
}
