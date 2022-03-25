using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class AssassinNpc : Npc
    {
        internal int MinReward { get; private set; }
        internal int MaxReward { get; private set; }
        internal string OfferMessage { get; private set; }
        internal bool IsBusy { get; set; }

        public AssassinNpc(string name, string meetMessage, string acceptMessage, string denyMessage, string offerMessage, int minReward, int maxReward) 
            : base(name, meetMessage, acceptMessage, denyMessage)
        {
            MinReward = minReward;
            MaxReward = maxReward;
            OfferMessage = offerMessage;
        }

        internal override void Accept(Player player)
        {
            View.ShowMessage(OfferMessage);
            var reward = int.Parse(View.ReadResponce(0));
            if (player.TryDecreaseMoney(reward)
                && AssassinsGuild.CheckOrder(reward))
            {
                View.ShowMessage(AcceptMessage);
                return;
            }
            else
            {
                Deny(player);
            }
        }
    }
}
