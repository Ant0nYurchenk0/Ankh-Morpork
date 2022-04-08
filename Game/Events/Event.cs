using Game.Guilds;
using Game.Views;
using Game.Players;
using Game.Constants;
using Game.Npcs;


namespace Game.Events
{
    public class Event : IEvent
    {
        public INpc Npc { get; private set; }
        public IGuild Guild { get; private set; }
        public bool Resolved { get; private set; }
        public IView View { get; set; }

        public Event(INpc npc, IGuild guild)
        {
            Npc = npc;
            Guild = guild;
            View = new View();
            Resolved = false;

        }

        public void Resolve(IPlayer player)
        {
            var isNew = true;
            if (Npc == null)
                Resolved = true;
            while (!Resolved)
            {
                View.ShowEvent(this, isNew);
                View.ShowInventory(player);
                var options = View.ShowOptions(Option.ACCEPT, Option.DENY, Option.HELP);
                switch (View.ReadResponse(options))
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

        private void Accept(IPlayer player)
        {
            Npc.Accept(player);
            Resolved = true;
        }

        private void Deny(IPlayer player)
        {
            Npc.Deny(player);
            Resolved = true;
        }

        private void Help()
        {
            View.ShowMessage(Guild.Description);
        }
    }
}
