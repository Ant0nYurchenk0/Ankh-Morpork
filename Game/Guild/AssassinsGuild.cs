using System;
using Newtonsoft.Json.Linq;

namespace Game
{
    public class AssassinsGuild : Guild, IAssassinsGuild
    {
        public AssassinsGuild(string guildName, ConsoleColor color = ConsoleColor.White,
            IDataRetrieveService dataRetriever = null)
            : base(guildName, color, dataRetriever) { }

        public string OfferMessage { get; protected set; }
        public override Npc GetNpc()
        {
            RandomizeAvailability();
            return base.GetNpc();
        }
        public bool CheckOrder(double reward)
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
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                Npcs.Add(new AssassinNpc((npc[Constant.Name] ?? string.Empty).ToString(),
                                            (npc[Constant.MeetMessage] ?? string.Empty).ToString(),
                                            (npc[Constant.AcceptMessage] ?? string.Empty).ToString(),
                                            (npc[Constant.DenyMessage] ?? string.Empty).ToString(),
                                            (npc[Constant.OfferMessage] ?? string.Empty).ToString(),
                                            (double)(npc[Constant.MinReward] ?? 0),
                                            (double)(npc[Constant.MaxReward] ?? 0),
                                            this));
            }
        }
    }
}
//([\w]+\[+[\w\.]+\])(?! \?\?)
//$1($2 ?? 0)

//([\w]+\[+[\w\.]+\])(?! \?\?)(\.ToString)
//($1 ?? string.Empty)$2