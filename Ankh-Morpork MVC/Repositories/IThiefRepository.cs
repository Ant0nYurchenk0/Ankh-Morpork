namespace Ankh_Morpork_MVC.Repositories
{
    public interface IThiefRepository : IEventProcessRepository
    {
        void AddFee(double fee);
    }
}