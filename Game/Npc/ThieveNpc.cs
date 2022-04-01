namespace Game
{
    public class ThieveNpc : Npc
    {
        public ThieveNpc(string name, string meetMessage, string acceptMessage, string denyMessage, 
            IThievesGuild guild, 
            IView view = null) 
            : base(name, meetMessage, acceptMessage, denyMessage, view)
        {
            _guild = guild;
        }
        private IThievesGuild _guild;
        public override void Accept(IPlayer player)
        {
            if (player.TryDecreaseMoney(_guild.DefaultFee))
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
