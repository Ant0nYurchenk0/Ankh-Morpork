using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Player : IDisposable
    {
        internal bool IsAlive { get; set; }
        internal int CurrentScore { get; private set; } = 0;
        internal int HighScore { get; private set; }
        internal int Money { get; private set; } = 100;
        private JObject _playerData;

        internal Player()
        {
            IsAlive = true;
            var configStr = ServiceFile.ReadFile(Config.PlayerDataPath);
            _playerData = JObject.Parse(configStr);
            HighScore = (int)_playerData["HighScore"];
        }
        internal void IncreaseScore()
        {
            CurrentScore++;
            if(CurrentScore >= HighScore)
                HighScore = CurrentScore;

        }
        internal bool TryDecreaseMoney(int reward)
        {
            if (reward > Money)
                return false;
            else
            {
                Money -= reward;
                return true;
            }
        }
        internal void Reset()
        {
            HighScore = 0;
            LogData();
        }
        public void Dispose()
        {
            if ((int)_playerData["HighScore"] < HighScore)
            {
                LogData();
            }
        }
        private void LogData()
        {
            _playerData["HighScore"] = HighScore;
            string updatedData = JsonConvert.SerializeObject(_playerData);
            ServiceFile.WriteToFile(Config.PlayerDataPath, updatedData);
        }
    }
}
