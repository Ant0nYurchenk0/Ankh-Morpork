namespace Game
{
    public interface INpc
    {
        string AcceptMessage { get; }
        string DenyMessage { get; }
        string MeetMessage { get; }
        string Name { get; }

        void Accept(IPlayer player);
        void Deny(IPlayer player);
    }
}