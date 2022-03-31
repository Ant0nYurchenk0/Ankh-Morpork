using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Game
{
    public class Player : IDisposable, IPlayer
    {
        public bool IsAlive { get; set; }
        public int CurrentScore { get; private set; }
        public int HighScore { get; private set; }
        public double Money { get; private set; }
        private JObject _playerData;
        private static IFileService _serviceFile;

        public Player(IFileService serviceFile = null)
        {
            _serviceFile = serviceFile ?? new FileService();
            IsAlive = true;
            CurrentScore = 0;
            var configStr = _serviceFile.ReadFile(Config.PlayerDataPath);
            _playerData = JObject.Parse(configStr);
            HighScore = (int)(_playerData[Constant.HighScore] ?? 0);
            Money = (double)(_playerData[Constant.Money] ?? 0);
        }
        public void IncreaseScore()
        {
            CurrentScore++;
            if (CurrentScore >= HighScore)
                HighScore = CurrentScore;

        }
        public void IncreaseMoney(double amount)
        {
            Money += amount;
        }
        public bool TryDecreaseMoney(double reward)
        {
            if (reward > Money)
                return false;
            else
            {
                Money -= reward;
                return true;
            }
        }
        public void Reset()
        {
            HighScore = 0;
            LogData();
        }
        public void Dispose()
        {
            if ((int)_playerData[Constant.HighScore] < HighScore)
            {
                LogData();
            }
        }
        private void LogData()
        {
            _playerData[Constant.HighScore] = HighScore;
            string updatedData = JsonConvert.SerializeObject(_playerData);
            _serviceFile.WriteToFile(Config.PlayerDataPath, updatedData);
        }
    }
}
