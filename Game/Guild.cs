using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Game
{
    internal abstract class Guild
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public List<Npc> Npcs { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        internal Guild(string guildName, ConsoleColor color = ConsoleColor.White)
        {
            Name = guildName;
            Color = color;
            LoadData();
            Npcs = new List<Npc>();
            LoadNpcs();
        }
        internal virtual Npc GetNpc()
        {
            var rnd = new Random();
            var randomNpcNumber = rnd.Next(0, Npcs.Count);
            return Npcs[randomNpcNumber];
        }
        protected virtual void LoadNpcs()
        {
            var npcJson = ServiceFile.ReadFile(Config.GuildsPath);
            var listOfGuilds = JArray.Parse(npcJson);
            var listOfNpcs = (from guild in listOfGuilds
                              where guild[Constant.Name].ToString() == Name
                              select guild[Constant.Npcs]).FirstOrDefault() as JArray;
            CreateNpcs(listOfNpcs);
        }
        protected virtual void LoadData()
        {
            var configStr = ServiceFile.ReadFile(Config.GuildsPath);
            var guilds = JArray.Parse(configStr);
            var guildData = (from guild in guilds.Children<JObject>()
                             where guild[Constant.Name].ToString() == Name
                             select guild).FirstOrDefault();
            Description = guildData[Constant.Description].ToString();
            InitFields(guildData);
        }
        protected virtual void InitFields(JObject guildData) { }
        protected abstract void CreateNpcs(JArray listOfNpcs);
    }
}
