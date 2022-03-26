using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class ThievesGuild : Guild
    {
        internal static int DefaultFee { get; private set; }
        private int _maxThieves;
        protected override void LoadData()
        {
            var configStr = ServiceFile.ReadFile(Config.GuildsPath);
            var guilds = JArray.Parse(configStr);
            var guildData = (from guild in guilds.Children<JObject>()
                             where guild[Constant.Name].ToString() == Constant.ThievesGuild
                             select guild).FirstOrDefault();
            Name = guildData[Constant.Name].ToString();
            Description = guildData[Constant.Description].ToString();
            DefaultFee = (int)guildData[Constant.DefaultFee];
            _maxThieves = (int)guildData[Constant.MaxThieves];
        }

        protected override void LoadNpcs()
        {
            var npcJson = ServiceFile.ReadFile(Config.GuildsPath);
            var listOfGuilds = JArray.Parse(npcJson);
            var listOfNpcs = (from guild in listOfGuilds
                              where guild[Constant.Name].ToString() == Constant.ThievesGuild
                              select guild[Constant.Npcs]).FirstOrDefault() as JArray;
            var counter = 0;
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                if (counter > _maxThieves) break;
                counter++;
                Npcs.Add(new ThieveNpc(npc[Constant.Name].ToString(),
                                            npc[Constant.MeetMessage].ToString(),
                                            npc[Constant.AcceptMessage].ToString(),
                                            npc[Constant.DenyMessage].ToString()));
            }
            Color = ConsoleColor.DarkMagenta;
        }
        internal override Npc GetNpc()
        {
            if (Npcs.Count <= 0)
                return null;
            var selectedNpc = base.GetNpc();
            Npcs.Remove(selectedNpc);
            return selectedNpc;
        }
    }
}
