namespace Ankh_Morpork_MVC.Repositories
{
    public interface IGameRepository
    {
        void AddDate();
        void AddScore();
        void PostGame();
        void ResetGame();
    }
}