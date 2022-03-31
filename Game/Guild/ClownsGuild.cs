using System;
using Newtonsoft.Json.Linq;

namespace Game
{
    public class ClownsGuild : Guild
    {
        public ClownsGuild(string guildName, ConsoleColor color = ConsoleColor.White, IDataRetrieveService dataRetriever = null) 
            : base(guildName, color, dataRetriever) { }
        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var types = _dataRetriever.RetrieveTypes(Config.ClownTypesPath);
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                Npcs.Add(new ClownNpc((npc[Constant.Name] ?? string.Empty).ToString(),
                                            (npc[Constant.MeetMessage] ?? string.Empty).ToString(),
                                            (npc[Constant.AcceptMessage] ?? string.Empty).ToString(),
                                            (npc[Constant.DenyMessage] ?? string.Empty).ToString(),
                                            (double)(types[(npc[Constant.Type] ?? string.Empty).ToString()] ?? 0)));
            }
        }
    }
}
