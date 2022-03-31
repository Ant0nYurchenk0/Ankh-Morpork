namespace Game
{
    public interface IPlayer
    {
        int CurrentScore { get; }
        int HighScore { get; }
        bool IsAlive { get; set; }
        double Money { get; }

        void Dispose();
        void IncreaseMoney(double amount);
        void IncreaseScore();
        void Reset();
        bool TryDecreaseMoney(double reward);
    }
}