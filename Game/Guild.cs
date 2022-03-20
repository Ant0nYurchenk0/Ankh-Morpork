using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ankh_Morpork
{
    internal abstract class Guild
    {
        internal Guild()
        {
            faculty = new List<Npc>();
            loadData();
            if (faculty.Count == 0)
                throw new DllNotFoundException("Error: Source file absent or damaged");
        }
        internal string Name { get => name;}
        internal string Description { get => description;}
        internal List<Npc> Faculty { get => faculty;}
        internal abstract Npc GetNpc();

        protected string name;
        protected string description;
        protected List<Npc> faculty;

        protected abstract void loadData();
    }
}
