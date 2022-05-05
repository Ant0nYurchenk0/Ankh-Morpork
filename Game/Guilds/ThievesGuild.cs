using Game.Builders;
using Game.Constants;
using Game.Npcs;
using Game.Service;
using Newtonsoft.Json.Linq;
using System;


namespace Game.Guilds
{
    public class ThievesGuild : Guild, IThievesGuild
    {
        public decimal DefaultFee { get; private set; }
        private int _maxEvents;
        public static int EventCounter { get; private set; } = 0;

        public ThievesGuild(string guildName, ConsoleColor color = ConsoleColor.White, IDataRetrieveService dataRetriever = null)
            : base(guildName, color, dataRetriever) { }

        protected override void LoadData()
        {
            base.LoadData();
            InitFields();
        }

        protected override void CreateNpcs(JArray listOfNpcs)
        {
            var builder = new ThieveBuilder();
            foreach (var npc in listOfNpcs.Children<JObject>())
            {
                builder.Reset();
                builder.AddName(Convert.ToString(npc[Constant.Name]));
                builder.AddMessages(DataRetriever.RetrieveMessages(npc));
                builder.AddGuild(this);
                Npcs.Add(builder.GetNpc());
            }
        }

        public override Npc GetNpc()
        {
            var selectedNpc = base.GetNpc();
            EventCounter++;
            if (EventCounter <= _maxEvents)
                IsActive = false;
            return selectedNpc;
        }

        private void InitFields()
        {
            if (decimal.TryParse(DataRetriever.RetrieveGuildData(Constant.DefaultFee, Name, Config.GuildsPath),
                out var defaultFee))
            {
                DefaultFee = defaultFee;
            }
            int.TryParse(DataRetriever.RetrieveGuildData(Constant.MaxThieves, Name, Config.GuildsPath), out _maxEvents);
        }
    }
}
