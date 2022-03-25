using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Game
{
    internal class AssassinsGuild : Guild
    {
        public string OfferMessage { get; protected set; }
        protected override void LoadNpcs()
        {
            var npcJson = ServiceFile.ReadFile(Config.AssassinsGuildNpcsPath);
            var listOfNpcs = JArray.Parse(npcJson);
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                Npcs.Add(new AssassinNpc(npc["Name"].ToString(),
                                            npc["MeetMessage"].ToString(),
                                            npc["AcceptMessage"].ToString(),
                                            npc["DenyMessage"].ToString(),
                                            npc["OfferMessage"].ToString(),
                                            (int)npc["MinReward"],
                                            (int)npc["MaxReward"],
                                            this));
            }
            Color = ConsoleColor.DarkGray;
        }
        internal override Npc GetNpc()
        {
            OccupyFaculty(); // randomize the availability of each assassin
            return base.GetNpc();
        }
        internal bool CheckOrder(int reward)
        {
            foreach(AssassinNpc npc in Npcs)
            {
                if (!npc.IsBusy 
                    && npc.MaxReward >= reward
                    && npc.MinReward <= reward)
                {
                    return true;
                }
            }
            return false;
        }
        protected override void LoadData()
        {
            var configStr = ServiceFile.ReadFile(Config.AssassinsGuildPath);
            var guildData = JObject.Parse(configStr);
            Name = guildData["Name"].ToString();
            Description = guildData["Description"].ToString();
        }
        private void OccupyFaculty()
        {
            var rnd = new Random();
            foreach (AssassinNpc npc in Npcs)
            {
                npc.IsBusy = Convert.ToBoolean(rnd.Next(0, 2));  
            }
        }
    }
}
