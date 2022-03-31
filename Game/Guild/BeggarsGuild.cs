using System;
using Newtonsoft.Json.Linq;

namespace Game
{
    public class BeggarsGuild : Guild
    {
        public BeggarsGuild(string guildName, ConsoleColor color = ConsoleColor.White, IDataRetrieveService dataRetriever = null) 
            : base(guildName, color, dataRetriever) { }

        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var types = _dataRetriever.RetrieveTypes(Config.BeggarTypesPath);
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                Npcs.Add(new BeggarNpc((npc[Constant.Name] ?? string.Empty).ToString(),
                                            (npc[Constant.MeetMessage] ?? string.Empty).ToString(),
                                            (npc[Constant.AcceptMessage] ?? string.Empty).ToString(),
                                            (npc[Constant.DenyMessage] ?? string.Empty).ToString(),
                                            (double)(types[npc[Constant.Type].ToString()] ?? 0)));
            }
        }
    }
}
