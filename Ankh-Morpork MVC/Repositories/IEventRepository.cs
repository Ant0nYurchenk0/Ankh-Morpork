using Ankh_Morpork_MVC.Models;

namespace Ankh_Morpork_MVC.Repositories
{
    public interface IEventRepository
    {
        void AddBeer(double playerBeer);
        void AddBody();
        void AddHood(double playerHood);
        void AddMoney(double money);
        void AddScore(int score);
        Event GetEvent();
        void PostEvent();
        void ResetEvent();
        void SetThievesMet(int thievesMet);
        string ViewEvent();
    }
}