using System;
using Newtonsoft.Json.Linq;

namespace Game
{
    public class ThievesGuild : Guild, IThievesGuild
    {
        public decimal DefaultFee { get; private set; }
        private int _maxEvents;
        private static int _eventCounter = 0;

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
            foreach (JObject npc in listOfNpcs.Children<JObject>())
            {
                builder.Reset();
                builder.AddName(Convert.ToString(npc[Constant.Name]));
                builder.AddMessages(_dataRetriever.RetrieveMessages(npc));
                builder.AddGuild(this);
                Npcs.Add(builder.GetNpc());
            }
        }

        public override Npc GetNpc()
        {
            var selectedNpc = base.GetNpc();
            _eventCounter++;
            if (_eventCounter <= _maxEvents)
                IsActive = false;
            return selectedNpc;
        }

        private void InitFields()
        {
            if (decimal.TryParse(_dataRetriever.RetrieveGuildData(Constant.DefaultFee, Name, Config.GuildsPath),
                out var defaultFee))
            {
                DefaultFee = defaultFee;
            }
            int.TryParse(_dataRetriever.RetrieveGuildData(Constant.MaxThieves, Name, Config.GuildsPath), out _maxEvents);
        }
    }
}
