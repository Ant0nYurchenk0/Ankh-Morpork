using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class BeggarsGuild : Guild
    {

        protected override void LoadData()
        {
            var configStr = ServiceFile.ReadFile(Config.GuildsPath);
            var guilds = JArray.Parse(configStr);
            var guildData = (from guild in guilds.Children<JObject>()
                             where guild[Constant.Name].ToString() == Constant.BeggarsGuild
                             select guild).FirstOrDefault();
            Name = guildData[Constant.Name].ToString();
            Description = guildData[Constant.Description].ToString();
        }

        protected override void LoadNpcs()
        {
            var typesJson = ServiceFile.ReadFile(Config.BeggarTypesPath);
            var types = JObject.Parse(typesJson);
            var npcJson = ServiceFile.ReadFile(Config.GuildsPath);
            var listOfGuilds = JArray.Parse(npcJson);
            var listOfNpcs = (from guild in listOfGuilds
                              where guild[Constant.Name].ToString() == Constant.BeggarsGuild
                              select guild[Constant.Npcs]).FirstOrDefault() as JArray;
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                Npcs.Add(new BeggarNpc(npc[Constant.Name].ToString(),
                                            npc[Constant.MeetMessage].ToString(),
                                            npc[Constant.AcceptMessage].ToString(),
                                            npc[Constant.DenyMessage].ToString(),
                                            (double)types[npc[Constant.Type].ToString()]));
            }
            Color = ConsoleColor.DarkRed;
        }
    }
}
