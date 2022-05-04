namespace Ankh_Morpork_MVC.Repositories
{
    public interface IAssassinRepository : IEventProcessRepository
    {
        void AddReward(double reward, bool hood);
    }
}