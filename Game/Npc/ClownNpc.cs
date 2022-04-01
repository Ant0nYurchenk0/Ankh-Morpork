namespace Game
{
    public class ClownNpc : Npc
    {
        public double Reward { get; private set; }
        public ClownNpc(string name, string meetMessage, string acceptMessage, string denyMessage, 
            double reward,
            IView view = null) 
            : base(name, meetMessage, acceptMessage, denyMessage, view)
        {
            Reward = reward;
        }

        public override void Accept(IPlayer player)
        {
            base.Accept(player);
            _view.ShowMessage(AcceptMessage);
            player.IncreaseMoney(Reward);
        }
        public override void Deny(IPlayer player)
        {
            _view.ShowMessage(DenyMessage);
        }
    }
}
