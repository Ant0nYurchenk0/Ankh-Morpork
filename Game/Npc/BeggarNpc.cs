namespace Game
{
    public class BeggarNpc : Npc
    {
        public double Fee { get; private set; }
        public BeggarNpc(string name, string meetMessage, string acceptMessage, string denyMessage, double fee)
            : base(name, meetMessage, acceptMessage, denyMessage)
        {
            Fee = fee;  
        }
        public override void Accept(IPlayer player)
        {
            if (player.TryDecreaseMoney(Fee))
            {
                base.Accept(player);
                View.ShowMessage(AcceptMessage);
                return;
            }
            else
            {
                Deny(player);
            }
        }
    }
}
