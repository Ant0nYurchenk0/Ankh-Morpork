namespace Game
{
    public interface IPlayer
    {
        int CurrentScore { get; }
        int HighScore { get; }
        bool IsAlive { get; set; }
        decimal Money { get; }

        void Dispose();
        void IncreaseMoney(decimal amount);
        void IncreaseScore();
        void Reset();
        bool TryDecreaseMoney(decimal reward);
    }
}