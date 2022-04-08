using Game.Guilds;
using Game.Players;
using Game.Npcs;


namespace Game.Events
{
    public interface IEvent
    {
        IGuild Guild { get; }
        INpc Npc { get; }
        void Resolve(IPlayer player);
    }
}