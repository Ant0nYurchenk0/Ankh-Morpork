using Game.Constants;
using Game.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Game.Players
{
    public class Player : IPlayer
    {
        public bool IsAlive { get; set; }
        public int CurrentScore { get; private set; }
        public int HighScore { get; private set; }
        public decimal Money { get; private set; }
        public JObject PlayerData { get; private set; }
        private readonly IFileService _serviceFile;

        public Player(IFileService serviceFile = null)
        {
            _serviceFile = serviceFile ?? new FileService();
            IsAlive = true;
            CurrentScore = 0;
            var configStr = _serviceFile.ReadFile(Config.PlayerDataPath);
            PlayerData = JObject.Parse(configStr);
            HighScore = (int)(PlayerData[Constant.HighScore] ?? 0);
            Money = (decimal)(PlayerData[Constant.Money] ?? 0);
        }

        public void IncreaseScore()
        {
            CurrentScore++;
            if (CurrentScore >= HighScore)
                HighScore = CurrentScore;

        }

        public void IncreaseMoney(decimal amount)
        {
            Money += amount;
        }

        public bool TryDecreaseMoney(decimal reward)
        {
            if (reward > Money)
                return false;

            Money -= reward;
            return true;

        }

        public void Reset()
        {
            HighScore = 0;
            LogData();
        }

        public void Dispose()
        {
            if ((int)PlayerData[Constant.HighScore] < HighScore)
            {
                LogData();
            }
        }

        private void LogData()
        {
            PlayerData[Constant.HighScore] = HighScore;
            string updatedData = JsonConvert.SerializeObject(PlayerData);
            _serviceFile.WriteToFile(Config.PlayerDataPath, updatedData);
        }
    }
}
