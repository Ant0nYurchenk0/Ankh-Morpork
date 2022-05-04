namespace Ankh_Morpork_MVC.Repositories
{
    public interface IClownRepository : IEventProcessRepository
    {
        void AddReward(double reward);
    }
}