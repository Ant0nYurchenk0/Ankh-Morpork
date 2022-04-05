using System;
using Newtonsoft.Json.Linq;

namespace Game
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
            foreach (AssassinNpc npc in Npcs)
            {
                if (!npc.IsBusy
                    && npc.MaxReward >= reward
                    && npc.MinReward <= reward)
                {
                    return true;
                }
            }
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
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                builder.Reset();
                builder.AddMaxReward(Convert.ToDecimal(npc[Constant.MaxReward]));
                builder.AddMinReward(Convert.ToDecimal(npc[Constant.MinReward]));
                builder.AddMessages(_dataRetriever.RetrieveMessages(npc));
                builder.AddName(Convert.ToString(npc[Constant.Name]));
                builder.AddGuild(this);
                Npcs.Add(builder.GetNpc());
            }
        }
    }
}
//([\w]+\[+[\w\.]+\])(?! \?\?)
//$1($2 ?? 0)

//([\w]+\[+[\w\.]+\])(?! \?\?)(\.ToString)
//($1 ?? string.Empty)$2