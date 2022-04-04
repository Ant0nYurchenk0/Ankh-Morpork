using System;

namespace Game
{
    public class AssassinNpc : Npc
    {
        public double MinReward { get; set; } 
        public double MaxReward { get; set; } 
        public bool IsBusy { get; set; }
        public IAssassinsGuild Guild { get; set; }
        public AssassinNpc(IView view = null) 
            : base(view) {}

        public override void Accept(IPlayer player)
        {
            try
            {
                _view.ShowMessage(Messages[Constant.OfferMessage]);
            }
            catch(Exception) { }
            var reward = double.Parse(_view.ReadResponce(0));
            if (player.TryDecreaseMoney(reward)
                && Guild.CheckOrder(reward))
            {
                base.Accept(player);
                try
                {
                    _view.ShowMessage(Messages[Constant.AcceptMessage]);
                }
                catch (Exception) { }
                return;
            }
            else
            {
                Deny(player);
            }
        }
    }
}
