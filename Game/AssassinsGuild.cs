﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Game
{
    internal class AssassinsGuild : Guild
    {
        public string OfferMessage { get; protected set; }
        protected override void LoadNpcs()
        {
            var npcJson = ServiceFile.ReadFile(Config.GuildsPath);
            var listOfGuilds = JArray.Parse(npcJson);
            var listOfNpcs = (from guild in listOfGuilds
                             where guild[Constant.Name].ToString() == Constant.AssassinsGuild
                              select guild[Constant.Npcs]).FirstOrDefault() as JArray;
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
            Color = ConsoleColor.DarkGray;
        }
        internal override Npc GetNpc()
        {
            OccupyFaculty(); // randomize the availability of each assassin
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
        protected override void LoadData()
        {
            var configStr = ServiceFile.ReadFile(Config.GuildsPath);
            var guilds = JArray.Parse(configStr);
            var guildData = (from guild in guilds.Children<JObject>()
                            where guild[Constant.Name].ToString() == Constant.AssassinsGuild
                            select guild).FirstOrDefault();
            Name = guildData[Constant.Name].ToString();
            Description = guildData[Constant.Description].ToString();
        }
        private void OccupyFaculty()
        {
            var rnd = new Random();
            foreach (AssassinNpc npc in Npcs)
            {
                npc.IsBusy = Convert.ToBoolean(rnd.Next(0, 2));  
            }
        }
    }
}
