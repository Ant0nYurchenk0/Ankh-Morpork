namespace Game
{
    public class BeggarNpc : Npc
    {
        public double Fee { get; private set; }
        public BeggarNpc(string name, string meetMessage, string acceptMessage, string denyMessage, 
            double fee,
            IView view = null)
            : base(name, meetMessage, acceptMessage, denyMessage, view)
        {
            Fee = fee;  
        }
        public override void Accept(IPlayer player)
        {
            if (player.TryDecreaseMoney(Fee))
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
