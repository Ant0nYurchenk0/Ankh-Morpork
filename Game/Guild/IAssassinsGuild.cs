namespace Game
{
    public interface IAssassinsGuild
    {
        string OfferMessage { get; }
        bool CheckOrder(double reward);
    }
}