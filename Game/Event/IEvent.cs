namespace Game
{
    public interface IEvent
    {
        IGuild Guild { get; }
        INpc Npc { get; }
        void Resolve(IPlayer player);
    }
}