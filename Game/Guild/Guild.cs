using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Game
{
    public abstract class Guild : IGuild
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public List<Npc> Npcs { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        protected static IDataRetrieveService _dataRetriever;
        public Guild(string guildName, ConsoleColor color = ConsoleColor.White, IDataRetrieveService dataRetriever = null)
        {
            _dataRetriever = dataRetriever ?? new DataRetrieveService();
            Name = guildName;
            Color = color;
            LoadData();
            Npcs = new List<Npc>();
            LoadNpcs();
        }
        public virtual Npc GetNpc()
        {
            var randomNpcNumber = EventBuilder.Random.Next(0, Npcs.Count);
            return Npcs[randomNpcNumber];
        }
        protected virtual void LoadNpcs()
        {
            var listOfNpcs = _dataRetriever.RetrieveNpcs(Name, Config.GuildsPath);
            CreateNpcs(listOfNpcs);
        }
        protected virtual void LoadData()
        {
            Description = _dataRetriever.RetrieveGuildData(Constant.Description, Name, Config.GuildsPath);
        }
        protected abstract void CreateNpcs(JArray listOfNpcs);
    }
}
