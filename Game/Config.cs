using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Game
{
    internal static class Config
    {
        internal static string ConfigPath { get; set; }
        internal static string PlayerDataPath { get ; private set; }
        internal static string AssassinsGuildNpcsPath { get ; private set; }
        internal static string AssassinsGuildPath { get; private set; }

        internal static void LoadConfig()
        {
            var configString = ServiceFile.ReadFile(ConfigPath);
            var config = JObject.Parse(configString);
            PlayerDataPath = config["PlayerDataPath"].ToString();
            AssassinsGuildNpcsPath = config["AssassinsGuildNpcsPath"].ToString();
            AssassinsGuildPath = config["AssassinsGuildPath"].ToString();
        }
       
    }
}
