using System;
using Newtonsoft.Json.Linq;

namespace Game
{
    internal class BeggarsGuild : Guild
    {
        public BeggarsGuild(string guildName, ConsoleColor color = ConsoleColor.White) : base(guildName, color) { }

        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var typesJson = ServiceFile.ReadFile(Config.BeggarTypesPath);
            var types = JObject.Parse(typesJson);
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                Npcs.Add(new BeggarNpc(npc[Constant.Name].ToString(),
                                            npc[Constant.MeetMessage].ToString(),
                                            npc[Constant.AcceptMessage].ToString(),
                                            npc[Constant.DenyMessage].ToString(),
                                            (double)types[npc[Constant.Type].ToString()]));
            }
        }
    }
}
