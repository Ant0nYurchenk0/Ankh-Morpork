namespace Game
{
    public abstract class Npc : INpc
    {
        public string Name { get; private set; }
        public string MeetMessage { get; private set; }
        public string AcceptMessage { get; private set; }
        public string DenyMessage { get; private set; }
        public Npc(string name, string meetMessage, string acceptMessage, string denyMessage)
        {
            Name = name;
            MeetMessage = meetMessage;
            AcceptMessage = acceptMessage;
            DenyMessage = denyMessage;
        }
        public virtual void Accept(IPlayer player)
        {
            player.IncreaseScore();
        }
        public virtual void Deny(IPlayer player)
        {
            View.ShowMessage(DenyMessage);
            player.IsAlive = false;
        }
    }
}
