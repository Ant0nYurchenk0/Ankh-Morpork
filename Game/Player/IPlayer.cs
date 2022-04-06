using System;

namespace Game
{
    public interface IPlayer : IDisposable
    {
        int CurrentScore { get; }
        int HighScore { get; }
        bool IsAlive { get; set; }
        decimal Money { get; }
        void IncreaseMoney(decimal amount);
        void IncreaseScore();
        void Reset();
        bool TryDecreaseMoney(decimal reward);
    }
}