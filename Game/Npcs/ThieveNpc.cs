using System.Linq;
using Game.Players;
using Game.Guilds;
using Game.Constants;


namespace Game.Npcs
{
    public class ThieveNpc : Npc
    {
        public ThieveNpc() : base() {}
        public IThievesGuild Guild { get; set; }
        public override void Accept(IPlayer player)
        {
            if (player.TryDecreaseMoney(Guild.DefaultFee))
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
