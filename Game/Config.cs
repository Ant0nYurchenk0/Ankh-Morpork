using Newtonsoft.Json.Linq;
using System;

namespace Game
{
    public static class Config
    {
        public static string ConfigPath { get; set; }
        public static string GuildsPath { get; private set; }
        public static string PlayerDataPath { get ; private set; }
        public static string BeggarTypesPath { get ; private set; }
        public static string ClownTypesPath { get ; private set; }
        public static IFileService ServiceFile { get; set; } 

        public static void LoadConfig()
        {
            ServiceFile = new FileService();
            try
            {
                var configString = ServiceFile.ReadFileCache(ConfigPath);
                var config = JObject.Parse(configString);
                PlayerDataPath = config[Path.PlayerDataConfigPath].ToString();
                GuildsPath = config[Path.GuildDataConfigPath].ToString();
                BeggarTypesPath = config[Path.BeggarTypesPath].ToString();
                ClownTypesPath = config[Path.ClownTypesPath].ToString() ;
            }
            catch 
            {
                throw new ArgumentException(Message.FileAccessError);
            }
        }
    }
}
