using System;
using Newtonsoft.Json.Linq;

namespace Game
{
    public class ThievesGuild : Guild, IThievesGuild
    {
        public double DefaultFee { get; private set; }
        private int _maxThieves;

        public ThievesGuild(string guildName, ConsoleColor color = ConsoleColor.White, IDataRetrieveService dataRetriever = null)
            : base(guildName, color, dataRetriever) { }

        protected override void LoadData()
        {
            base.LoadData();
            InitFields();
        }

        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var counter = 0;
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                if (counter >= _maxThieves) break;
                counter++;
                Npcs.Add(new ThieveNpc((npc[Constant.Name] ?? string.Empty).ToString(),
                                            (npc[Constant.MeetMessage] ?? string.Empty).ToString(),
                                            (npc[Constant.AcceptMessage] ?? string.Empty).ToString(),
                                            (npc[Constant.DenyMessage] ?? string.Empty).ToString(), 
                                            this));
            }
        }
        public override Npc GetNpc()
        {
            if (Npcs.Count <= 0)
                return null;
            var selectedNpc = base.GetNpc();
            Npcs.Remove(selectedNpc);
            return selectedNpc;
        }
        private void InitFields()
        {
            if (double.TryParse(_dataRetriever.RetrieveGuildData(Constant.DefaultFee, Name, Config.GuildsPath),
                out var defaultFee))
            {
                DefaultFee = defaultFee;
            }
            int.TryParse(_dataRetriever.RetrieveGuildData(Constant.MaxThieves, Name, Config.GuildsPath), out _maxThieves);
        }
    }
}
