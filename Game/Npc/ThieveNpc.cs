using System;

namespace Game
{
    public class ThieveNpc : Npc
    {
        public ThieveNpc(IView view = null) : base(view) {}
        public IThievesGuild Guild { get; set; }
        public override void Accept(IPlayer player)
        {
            if (player.TryDecreaseMoney(Guild.DefaultFee))
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
