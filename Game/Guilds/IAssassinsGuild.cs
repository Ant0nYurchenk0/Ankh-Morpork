
namespace Game.Guilds
{
    public interface IAssassinsGuild
    {
        string OfferMessage { get; }
        bool CheckOrder(decimal reward);
    }
}