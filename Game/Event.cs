using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal struct Event
    {
        internal Npc Npc { get; private set; }
        internal Guild Guild { get; private set; }
        private bool resolved;
        internal Event(Npc npc, Guild guild)
        {
            Npc = npc;
            Guild = guild;
            resolved = false;

        }
        internal void Resolve(Player player)
        {
            var isNew = true;
            if (Npc == null)
                resolved = true;
            while (!resolved)
            {
                View.ShowEvent(this, isNew);
                View.ShowInventory(player);
                var options = View.ShowOptions(Option.ACCEPT, Option.DENY, Option.HELP);
                switch (View.ReadResponce(options))
                {
                    case "1":
                        Accept(player);   
                        break;
                    case "2":
                        Deny(player);
                        break;
                    case "3":
                        Help();
                        break;
                }
                isNew = false;
            }
        }
        private void Accept(Player player)
        {
            Npc.Accept(player);
            resolved = true;
            player.IncreaseScore();
        }
        private void Deny(Player player)
        {
            Npc.Deny(player);
            resolved = true;
        }
        private void Help()
        { 
            View.ShowMessage(this.Guild.Description);
        }
    }
}
