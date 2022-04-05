using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal interface IClownBuilder : INpcBuilder<ClownNpc>
    {
        void AddReward(decimal reward);
    }
}
