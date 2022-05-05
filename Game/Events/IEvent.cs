using Game.Guilds;
using Game.Npcs;
using Game.Players;


namespace Game.Events
{
    public interface IEvent
    {
        IGuild Guild { get; }
        INpc Npc { get; }
        void Resolve(IPlayer player);
    }
}