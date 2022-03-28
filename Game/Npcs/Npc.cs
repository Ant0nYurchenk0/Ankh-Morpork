namespace Game
{
    internal abstract class Npc
    {
        internal string Name { get; private set; }
        internal string MeetMessage { get; private set; }
        internal string AcceptMessage { get; private set; }
        internal string DenyMessage { get; private set; }
        internal Npc(string name, string meetMessage, string acceptMessage, string denyMessage)
        {
            Name = name;
            MeetMessage = meetMessage;
            AcceptMessage = acceptMessage;
            DenyMessage = denyMessage;
        }
        internal virtual void Accept(Player player)
        {
            player.IncreaseScore();
        }
        internal virtual void Deny(Player player)
        {
            View.ShowMessage(DenyMessage);
            player.IsAlive = false;
        }
    }
}
