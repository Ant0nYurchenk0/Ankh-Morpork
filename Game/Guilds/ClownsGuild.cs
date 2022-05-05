using Game.Builders;
using Game.Constants;
using Game.Service;
using Newtonsoft.Json.Linq;
using System;

namespace Game.Guilds
{
    public class ClownsGuild : Guild
    {
        public ClownsGuild(string guildName, ConsoleColor color = ConsoleColor.White, IDataRetrieveService dataRetriever = null)
            : base(guildName, color, dataRetriever) { }
        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var builder = new ClownBuilder();
            foreach (var npc in listOfNpcs.Children<JObject>())
            {
                builder.Reset();
                builder.AddName(Convert.ToString(npc[Constant.Name]));
                builder.AddMessages(DataRetriever.RetrieveMessages(npc));
                builder.AddReward(DataRetriever.RetrieveFromType(Config.ClownTypesPath, Convert.ToString(npc[Constant.Type])));
                Npcs.Add(builder.GetNpc());
            }
        }
    }
}
