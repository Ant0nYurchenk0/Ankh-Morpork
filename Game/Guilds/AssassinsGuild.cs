using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Game.Npcs;
using Game.Builders;
using Game.Constants;
using Game.Service;
using Game.Events;



namespace Game.Guilds
{
    public class AssassinsGuild : Guild, IAssassinsGuild
    {
        public AssassinsGuild(string guildName, ConsoleColor color = ConsoleColor.White, IDataRetrieveService dataRetriever = null)
            : base(guildName, color, dataRetriever) { }

        public string OfferMessage { get; protected set; }
        public override Npc GetNpc()
        {
            RandomizeAvailability();
            return base.GetNpc();
        }

        public bool CheckOrder(decimal reward)
        {
            if (Npcs.Cast<AssassinNpc>().Any(n => !n.IsBusy
                     && n.MaxReward >= reward
                     && n.MinReward <= reward))
                return true;
            
            return false;
        }

        private void RandomizeAvailability()
        {
            foreach (AssassinNpc npc in Npcs)
            {
                npc.IsBusy = Convert.ToBoolean(EventBuilder.Random.Next(0, 2));
            }
        }

        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var builder = new AssassinBuilder();
            foreach (var npc in listOfNpcs.Children<JObject>())
            {
                builder.Reset();
                builder.AddMaxReward(Convert.ToDecimal(npc[Constant.MaxReward]));
                builder.AddMinReward(Convert.ToDecimal(npc[Constant.MinReward]));
                builder.AddMessages(DataRetriever.RetrieveMessages(npc));
                builder.AddName(Convert.ToString(npc[Constant.Name]));
                builder.AddGuild(this);
                Npcs.Add(builder.GetNpc());
            }
        }
    }
}