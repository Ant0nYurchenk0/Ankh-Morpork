using Game.Constants;
using Game.Service;
using Newtonsoft.Json.Linq;


namespace Game
{
    public static class Config
    {
        public static string ConfigPath { get; set; }
        public static string GuildsPath { get; private set; }
        public static string PlayerDataPath { get; private set; }
        public static string BeggarTypesPath { get; private set; }
        public static string ClownTypesPath { get; private set; }
        public static IFileService ServiceFile { get; set; }

        public static string LoadConfig()
        {
            ServiceFile = new FileService();
            if (ConfigPath == null)
                return string.Empty;
            var configString = ServiceFile.ReadFileCache(ConfigPath);
            var config = JObject.Parse(configString);
            if (string.IsNullOrEmpty(PlayerDataPath = LoadFromConfig(config, Path.PlayerDataConfigPath)))
            {
                return Path.PlayerDataConfigPath;
            }
            if (string.IsNullOrEmpty(GuildsPath = LoadFromConfig(config, Path.GuildDataConfigPath)))
            {
                return Path.GuildDataConfigPath;
            }
            if (string.IsNullOrEmpty(BeggarTypesPath = LoadFromConfig(config, Path.BeggarTypesPath)))
            {
                return Path.BeggarTypesPath;
            }
            if (string.IsNullOrEmpty(ClownTypesPath = LoadFromConfig(config, Path.ClownTypesPath)))
            {
                return Path.ClownTypesPath;
            }

            return string.Empty;

        }
        private static string LoadFromConfig(JObject config, string key)
        {
            if (config.TryGetValue(key, out var configData))
            {
                return configData.ToString();
            }
            else
                return null;
        }
    }
}
