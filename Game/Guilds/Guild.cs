using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Game.Constants;
using Game.Service;
using Game.Events;
using Game.Npcs;

namespace Game.Guilds
{
    public abstract class Guild : IGuild
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public List<Npc> Npcs { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public bool IsActive { get; protected set; }
        public IDataRetrieveService DataRetriever { get; set; }
        protected Guild(string guildName, ConsoleColor color = ConsoleColor.White, IDataRetrieveService dataRetriever = null)
        {
            DataRetriever = dataRetriever ?? new DataRetrieveService();
            Name = guildName;
            Color = color;
            IsActive = true;
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
            var listOfNpcs = DataRetriever.RetrieveNpcs(Name, Config.GuildsPath);
            CreateNpcs(listOfNpcs);
        }

        protected virtual void LoadData()
        {
            Description = DataRetriever.RetrieveGuildData(Constant.Description, Name, Config.GuildsPath);
        }

        protected abstract void CreateNpcs(JArray listOfNpcs);
    }
}
