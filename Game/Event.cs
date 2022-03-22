using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal struct Event
    {
        internal readonly Npc Npc;
        internal readonly Guild Guild;
        internal Event(Npc npc, Guild guild)
        {
            Npc = npc;
            Guild = guild;
        }
    }
}
