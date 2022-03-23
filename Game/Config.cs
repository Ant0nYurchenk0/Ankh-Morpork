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
        public static string AssassinsGuildNpcsPath { get ; private set; }
        public static string AssassinsGuildPath { get; private set; }

        internal static void LoadConfig()
        {
            var configString = File.ReadAllText(ConfigPath);
            var config = JObject.Parse(configString);
            AssassinsGuildNpcsPath = config["AssassinsGuildNpcsPath"].ToString();
            AssassinsGuildPath = config["AssassinsGuildPath"].ToString();
        }
       
    }
}
