using System;
using Newtonsoft.Json.Linq;

namespace Game
{
    internal class AssassinsGuild : Guild
    {
        public AssassinsGuild(string guildName, ConsoleColor color = ConsoleColor.White) : base(guildName, color) { }

        public string OfferMessage { get; protected set; }
        internal override Npc GetNpc()
        {
            RandomizeAvailability(); // randomize the availability of each assassin
            return base.GetNpc();
        }
        internal bool CheckOrder(int reward)
        {
            foreach(AssassinNpc npc in Npcs)
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
            var rnd = new Random();
            foreach (AssassinNpc npc in Npcs)
            {
                npc.IsBusy = Convert.ToBoolean(rnd.Next(0, 2));  
            }
        }
        protected override void CreateNpcs(JArray listOfNpcs)
        {
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                Npcs.Add(new AssassinNpc(npc[Constant.Name].ToString(),
                                            npc[Constant.MeetMessage].ToString(),
                                            npc[Constant.AcceptMessage].ToString(),
                                            npc[Constant.DenyMessage].ToString(),
                                            npc[Constant.OfferMessage].ToString(),
                                            (int)npc[Constant.MinReward],
                                            (int)npc[Constant.MaxReward],
                                            this));
            }
        }
    }
}
