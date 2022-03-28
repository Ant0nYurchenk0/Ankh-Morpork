using System;
using Newtonsoft.Json.Linq;

namespace Game
{
    internal class ClownsGuild : Guild
    {
        internal ClownsGuild(string guildName, ConsoleColor color = ConsoleColor.White) : base(guildName, color) { }
        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var typesJson = ServiceFile.ReadFileCache(Config.ClownTypesPath);
            var types = JObject.Parse(typesJson);
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                Npcs.Add(new ClownNpc(npc[Constant.Name].ToString(),
                                            npc[Constant.MeetMessage].ToString(),
                                            npc[Constant.AcceptMessage].ToString(),
                                            npc[Constant.DenyMessage].ToString(),
                                            (double)types[npc[Constant.Type].ToString()]));
            }
        }
    }
}
