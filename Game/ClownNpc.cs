namespace Game
{
    internal class ClownNpc : Npc
    {
        internal double Reward { get; private set; }
        public ClownNpc(string name, string meetMessage, string acceptMessage, string denyMessage, double reward) 
            : base(name, meetMessage, acceptMessage, denyMessage)
        {
            Reward = reward;
        }

        internal override void Accept(Player player)
        {
            View.ShowMessage(AcceptMessage);
            player.IncreaseMoney(Reward);
        }
        internal override void Deny(Player player)
        {
            View.ShowMessage(DenyMessage);
        }
    }
}
