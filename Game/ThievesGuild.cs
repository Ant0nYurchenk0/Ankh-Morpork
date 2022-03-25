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
            var configStr = ServiceFile.ReadFile(Config.ThievesGuildPath);
            var guildData = JObject.Parse(configStr);
            Name = guildData["Name"].ToString();
            Description = guildData["Description"].ToString();
            DefaultFee = (int)guildData["DefaultFee"];
            _maxThieves = (int)guildData["MaxThieves"];
        }

        protected override void LoadNpcs()
        {
            var npcJson = ServiceFile.ReadFile(Config.ThievesGuildNpcsPath);
            var listOfNpcs = JArray.Parse(npcJson);
            var counter = 0;
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                if (counter >= _maxThieves) break;
                Npcs.Add(new ThieveNpc(npc["Name"].ToString(),
                                            npc["MeetMessage"].ToString(),
                                            npc["AcceptMessage"].ToString(),
                                            npc["DenyMessage"].ToString()));
                counter++;
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
