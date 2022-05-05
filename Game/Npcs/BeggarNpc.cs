using Game.Constants;
using Game.Players;
using System.Linq;


namespace Game.Npcs
{
    public class BeggarNpc : Npc
    {
        public decimal Fee { get; set; }
        public BeggarNpc() : base() { }
        public override void Accept(IPlayer player)
        {
            if (player.TryDecreaseMoney(Fee))
            {
                base.Accept(player);
                _view.ShowMessage(Messages.FirstOrDefault(m => m.Key == Constant.AcceptMessage).Value);
            }
            else
            {
                if (Fee != 0)
                    Deny(player);
            }

        }
    }
}
