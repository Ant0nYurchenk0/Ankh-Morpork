namespace Game
{
    internal class ThieveNpc : Npc
    {
        public ThieveNpc(string name, string meetMessage, string acceptMessage, string denyMessage) 
            : base(name, meetMessage, acceptMessage, denyMessage) { }

        internal override void Accept(Player player)
        {
            if (player.TryDecreaseMoney(ThievesGuild.DefaultFee))
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
