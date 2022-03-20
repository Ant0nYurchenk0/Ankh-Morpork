using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ankh_Morpork
{
    internal abstract class Npc
    {

        internal string Name { get => name;}

        internal Npc(string name)
        {
            this.name = name;
        }
        protected string name;
    }
}
