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
            var builder = new ClownBuilder();
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                builder.Reset();
                builder.AddName(Convert.ToString(npc[Constant.Name]));
                builder.AddMessages(_dataRetriever.RetrieveMessages(npc));
                builder.AddReward(_dataRetriever.RetrieveFromType(Config.ClownTypesPath, Convert.ToString(npc[Constant.Type])));
                Npcs.Add(builder.GetNpc());
            }
        }
    }
}
