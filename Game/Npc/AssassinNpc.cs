namespace Game
{
    public class AssassinNpc : Npc
    {
        public double MinReward { get; private set; }
        public double MaxReward { get; private set; }
        public string OfferMessage { get; private set; }
        public bool IsBusy { get; set; }
        public IAssassinsGuild Guild { get; private set; }

        public AssassinNpc(string name, string meetMessage, string acceptMessage, string denyMessage, 
            string offerMessage, double minReward, double maxReward, IAssassinsGuild guild, 
            IView view = null) 
            : base(name, meetMessage, acceptMessage, denyMessage, view)
        {
            MinReward = minReward;
            MaxReward = maxReward;
            OfferMessage = offerMessage;
            Guild = guild;
        }

        public override void Accept(IPlayer player)
        {
            _view.ShowMessage(OfferMessage);
            var reward = double.Parse(_view.ReadResponce(0));
            if (player.TryDecreaseMoney(reward)
                && Guild.CheckOrder(reward))
            {
                base.Accept(player);
                _view.ShowMessage(AcceptMessage);
                return;
            }
            else
            {
                Deny(player);
            }
        }
    }
}
