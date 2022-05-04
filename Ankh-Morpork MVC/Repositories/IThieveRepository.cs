namespace Ankh_Morpork_MVC.Repositories
{
    public interface IThieveRepository : IEventProcessRepository
    {
        void AddFee(double fee);
    }
}