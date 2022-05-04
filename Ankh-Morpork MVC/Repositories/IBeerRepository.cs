namespace Ankh_Morpork_MVC.Repositories
{
    public interface IBeerRepository : IEventProcessRepository
    {
        void AddFee(double fee);
    }
}