using System;

namespace Game
{
    public class ClownNpc : Npc
    {
        public decimal Reward { get; set; }
        public ClownNpc(IView view = null) : base(view) {}

        public override void Accept(IPlayer player)
        {
            base.Accept(player);
            try
            {
                _view.ShowMessage(Messages[Constant.AcceptMessage]);
            }
            catch(Exception) { }
            finally
            {
                player.IncreaseMoney(Reward);
            }
        }

        public override void Deny(IPlayer player)
        {
            try
            {                
                _view.ShowMessage(Messages[Constant.DenyMessage]);
            }
            catch (Exception) { }
        }
    }
}
