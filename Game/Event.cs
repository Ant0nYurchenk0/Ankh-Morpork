using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ankh_Morpork
{
    internal struct Event
    {
        internal Npc Npc { get => npc;}
        internal Event(Npc npc)
        {
            this.npc = npc;
        }
        private Npc npc;

    }
}
