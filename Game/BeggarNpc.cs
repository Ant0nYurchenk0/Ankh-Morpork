namespace Game
{
    internal class BeggarNpc : Npc
    {
        internal double Fee { get; private set; }
        internal BeggarNpc(string name, string meetMessage, string acceptMessage, string denyMessage, double fee)
            : base(name, meetMessage, acceptMessage, denyMessage)
        {
            Fee = fee;  
        }
        internal override void Accept(Player player)
        {
            if (player.TryDecreaseMoney(Fee))
            {
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
