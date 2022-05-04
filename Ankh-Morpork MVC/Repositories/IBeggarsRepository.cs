namespace Ankh_Morpork_MVC.Repositories
{
    public interface IBeggarsRepository : IEventProcessRepository
    {
        void AddFees(double fee, bool beerFee);
    }
}