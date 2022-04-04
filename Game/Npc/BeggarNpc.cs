using System;

namespace Game
{
    public class BeggarNpc : Npc
    {
        public double Fee { get;  set; }
        public BeggarNpc(IView view = null) : base(view) {}
        public override void Accept(IPlayer player)
        {
            if (player.TryDecreaseMoney(Fee))
            {
                base.Accept(player);
                try
                {
                _view.ShowMessage(Messages[Constant.AcceptMessage]);
                }
                catch(Exception) { }
                return;
            }
            else
            {
                Deny(player);
            }
        }
    }
}
