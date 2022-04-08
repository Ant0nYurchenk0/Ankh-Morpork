using System.Linq;
using Game.Players;
using Game.Constants;


namespace Game.Npcs
{
    public class ClownNpc : Npc
    {
        public decimal Reward { get; set; }
        public ClownNpc() : base() {}

        public override void Accept(IPlayer player)
        {
            base.Accept(player);
            _view.ShowMessage(Messages.FirstOrDefault(m=>m.Key == Constant.AcceptMessage).Value);
            player.IncreaseMoney(Reward);
        }

        public override void Deny(IPlayer player)
        {               
            _view.ShowMessage(Messages.FirstOrDefault(m => m.Key == Constant.DenyMessage).Value);
        }
    }
}
