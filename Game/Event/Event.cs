namespace Game
{
    public class Event : IEvent
    {
        public INpc Npc { get; private set; }
        public IGuild Guild { get; private set; }
        public bool Resolved { get; private set; }
        private IView _view;
        public Event(INpc npc, IGuild guild, IView view = null)
        {
            Npc = npc;
            Guild = guild;
            _view = view ?? new View();
            Resolved = false;

        }
        public void Resolve(IPlayer player)
        {
            var isNew = true;
            if (Npc == null)
                Resolved = true;
            while (!Resolved)
            {
                _view.ShowEvent(this, isNew);
                _view.ShowInventory(player);
                var options = _view.ShowOptions(Option.ACCEPT, Option.DENY, Option.HELP);
                switch (_view.ReadResponce(options))
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
            _view.ShowMessage(Guild.Description);
        }
    }
}
