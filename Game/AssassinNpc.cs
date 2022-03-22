using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class AssassinNpc : Npc
    {
        internal readonly int MinReward;
        internal readonly int MaxReward;
        
        internal bool IsBusy { get; set; }


        public AssassinNpc(string name, string message, int minReward, int maxReward) : base(name, message)
        {
            MinReward = minReward;
            MaxReward = maxReward;
        }

        internal override void Accept(Player player)
        {
            Console.WriteLine("Offer accepted");
        }
    }
}
