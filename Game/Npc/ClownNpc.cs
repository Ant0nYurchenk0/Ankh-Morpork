namespace Game
{
    public class ClownNpc : Npc
    {
        public double Reward { get; private set; }
        public ClownNpc(string name, string meetMessage, string acceptMessage, string denyMessage, double reward) 
            : base(name, meetMessage, acceptMessage, denyMessage)
        {
            Reward = reward;
        }

        public override void Accept(IPlayer player)
        {
            base.Accept(player);
            View.ShowMessage(AcceptMessage);
            player.IncreaseMoney(Reward);
        }
        public override void Deny(IPlayer player)
        {
            View.ShowMessage(DenyMessage);
        }
    }
}
