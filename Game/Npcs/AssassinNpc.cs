using System.Linq;
using Game.Players;
using Game.Guilds;
using Game.Constants;

namespace Game.Npcs
{
    public class AssassinNpc : Npc
    {
        public decimal MinReward { get; set; } 
        public decimal MaxReward { get; set; } 
        public bool IsBusy { get; set; }
        public IAssassinsGuild Guild { get; set; }
        public AssassinNpc() 
            : base() {}

        public override void Accept(IPlayer player)
        {
            _view.ShowMessage(Messages.FirstOrDefault(m => m.Key == Constant.OfferMessage).Value);            
            var reward = decimal.Parse(_view.ReadResponse(0));
            if (player.TryDecreaseMoney(reward)
                && Guild.CheckOrder(reward))
            {
                base.Accept(player);
                _view.ShowMessage(Messages.FirstOrDefault(m => m.Key == Constant.AcceptMessage).Value);

            }
            else
            {
                Deny(player);
            }
        }
    }
}
