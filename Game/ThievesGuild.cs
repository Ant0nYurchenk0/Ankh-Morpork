using System;
using Newtonsoft.Json.Linq;

namespace Game
{
    internal class ThievesGuild : Guild
    {
        internal static double DefaultFee { get; private set; }
        private int _maxThieves;

        public ThievesGuild(string guildName, ConsoleColor color = ConsoleColor.White) : base(guildName, color){}

        protected override void InitFields(JObject guildData)
        {
            DefaultFee = (int)guildData[Constant.DefaultFee];
            _maxThieves = (int)guildData[Constant.MaxThieves];
        }

        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var counter = 0;
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                if (counter > _maxThieves) break;
                counter++;
                Npcs.Add(new ThieveNpc(npc[Constant.Name].ToString(),
                                            npc[Constant.MeetMessage].ToString(),
                                            npc[Constant.AcceptMessage].ToString(),
                                            npc[Constant.DenyMessage].ToString()));
            }
        }
        internal override Npc GetNpc()
        {
            if (Npcs.Count <= 0)
                return null;
            var selectedNpc = base.GetNpc();
            Npcs.Remove(selectedNpc);
            return selectedNpc;
        }
    }
}
