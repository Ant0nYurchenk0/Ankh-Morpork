using Newtonsoft.Json.Linq;

namespace Game
{
    internal static class Config
    {
        internal static string ConfigPath { get; set; }
        internal static string GuildsPath { get; private set; }
        internal static string PlayerDataPath { get ; private set; }
        internal static string BeggarTypesPath { get ; private set; }
        internal static string ClownTypesPath { get ; private set; }

        internal static void LoadConfig()
        {
            var configString = ServiceFile.ReadFileCache(ConfigPath);
            var config = JObject.Parse(configString);
            PlayerDataPath = config[Path.PlayerDataConfigPath].ToString();
            GuildsPath = config[Path.GuildDataConfigPath].ToString();
            BeggarTypesPath = config[Path.BeggarTypesPath].ToString();
            ClownTypesPath = config[Path.ClownTypesPath].ToString() ;
        }
    }
}
