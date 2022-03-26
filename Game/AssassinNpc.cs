using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class AssassinNpc : Npc
    {
        internal double MinReward { get; private set; }
        internal double MaxReward { get; private set; }
        internal string OfferMessage { get; private set; }
        internal bool IsBusy { get; set; }
        internal AssassinsGuild Guild { get; private set; }

        public AssassinNpc(string name, string meetMessage, string acceptMessage, string denyMessage, string offerMessage, int minReward, int maxReward, AssassinsGuild guild) 
            : base(name, meetMessage, acceptMessage, denyMessage)
        {
            MinReward = minReward;
            MaxReward = maxReward;
            OfferMessage = offerMessage;
            Guild = guild;
        }

        internal override void Accept(Player player)
        {
            View.ShowMessage(OfferMessage);
            var reward = int.Parse(View.ReadResponce(0));
            if (player.TryDecreaseMoney(reward)
                && Guild.CheckOrder(reward))
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
