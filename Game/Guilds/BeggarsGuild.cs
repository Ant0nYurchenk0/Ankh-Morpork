using Game.Builders;
using Game.Constants;
using Game.Service;
using Newtonsoft.Json.Linq;
using System;


namespace Game.Guilds
{
    public class BeggarsGuild : Guild
    {
        public BeggarsGuild(string guildName, ConsoleColor color = ConsoleColor.White, IDataRetrieveService dataRetriever = null)
            : base(guildName, color, dataRetriever) { }

        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var builder = new BeggarBuilder();
            foreach (var npc in listOfNpcs.Children<JObject>())
            {
                builder.Reset();
                builder.AddFee(DataRetriever.RetrieveFromType(Config.BeggarTypesPath, Convert.ToString(npc[Constant.Type])));
                builder.AddName(Convert.ToString(npc[Constant.Name]));
                builder.AddMessages(DataRetriever.RetrieveMessages(npc));
                Npcs.Add(builder.GetNpc());
            }
        }
    }
}
