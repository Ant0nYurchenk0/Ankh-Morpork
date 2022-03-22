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
        protected override void loadNpcs()
        {
            var npcJson = File.ReadAllText(Config.AssassinsGuildNpcsPath);
            var listOfNpcs = JArray.Parse(npcJson);
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                faculty.Add(new AssassinNpc(npc["Name"].ToString(),
                                            npc["Message"].ToString(),
                                            (int)npc["MinReward"],
                                            (int)npc["MaxReward"]));
            }
        }
        protected override void loadData()
        {
            var guildData = JObject.Parse(File.ReadAllText(Config.AssassinsGuildPath));
            name = guildData["Name"].ToString();
            description = guildData["Description"].ToString();
        }
        internal override Npc GetNpc()
        {
            occupyFaculty(); // randomize the availability of each assassin
            var rnd = new Random();
            var randomNpcNumber = rnd.Next(0, faculty.Count);
            return faculty[randomNpcNumber];
        }
        private void occupyFaculty()
        {
            var rnd = new Random();
            foreach (AssassinNpc npc in faculty)
            {
                npc.IsBusy = Convert.ToBoolean(rnd.Next());
                
            }
        }
    }
}
