using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Ankh_Morpork
{
    internal class AssassinsGuild : Guild
    {
        protected override void loadData()
        {
            var npcJson = File.ReadAllText(@"..\..\Source\Npcs\AGNpcs.json");
            var listOfNpcs = JArray.Parse(npcJson);
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                faculty.Add(new AssassinNpc(npc["name"].ToString()));
            }
        }

        internal override Npc GetNpc()
        {
            var rnd = new Random();
            var randomNpcNumber = rnd.Next(0, faculty.Count);
            return faculty[randomNpcNumber];
        }
    }
}
