namespace Game
{
    public abstract class Npc : INpc
    {
        public string Name { get; private set; }
        public string MeetMessage { get; private set; }
        public string AcceptMessage { get; private set; }
        public string DenyMessage { get; private set; }
        protected IView _view;
        public Npc(string name, string meetMessage, string acceptMessage, string denyMessage, IView view = null)
        {
            Name = name;
            MeetMessage = meetMessage;
            AcceptMessage = acceptMessage;
            DenyMessage = denyMessage;
            _view = view ?? new View();
        }
        public virtual void Accept(IPlayer player)
        {
            player.IncreaseScore();
        }
        public virtual void Deny(IPlayer player)
        {
            _view.ShowMessage(DenyMessage);
            player.IsAlive = false;
        }
    }
}
