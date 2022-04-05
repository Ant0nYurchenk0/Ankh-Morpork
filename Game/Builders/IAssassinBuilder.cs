using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal interface IAssassinBuilder : INpcBuilder<AssassinNpc>
    {
        void AddGuild(IAssassinsGuild guild);
        void AddMaxReward(decimal reward);
        void AddMinReward(decimal reward);
    }
}
