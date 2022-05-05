using Game.Constants;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Service
{
    public class DataRetrieveService : IDataRetrieveService
    {
        private IFileService _serviceFile;
        public DataRetrieveService(IFileService serviceFile = null)
        {
            _serviceFile = serviceFile ?? new FileService();
        }

        public decimal RetrieveFromType(string path, string type)
        {
            var types = RetrieveTypes(path);
            return Convert.ToDecimal(types[type]);
        }

        public string RetrieveGuildData(string fieldName, string guildName, string path)
        {
            var json = _serviceFile.ReadFileCache(path);
            var guilds = JArray.Parse(json);
            var guildData = guilds.Children<JObject>()
                .Where(guild => guild[Constant.Name].ToString() == guildName)
                .FirstOrDefault();
            return guildData[fieldName].ToString();
        }

        public Dictionary<string, string> RetrieveMessages(JObject npc)
        {
            var result = new Dictionary<string, string>();
            result.Add(Constant.MeetMessage, Convert.ToString(npc[Constant.MeetMessage]));
            result.Add(Constant.AcceptMessage, Convert.ToString(npc[Constant.AcceptMessage]));
            result.Add(Constant.DenyMessage, Convert.ToString(npc[Constant.DenyMessage]));
            result.Add(Constant.OfferMessage, Convert.ToString(npc[Constant.OfferMessage]));
            return result;
        }

        public JArray RetrieveNpcs(string guildName, string path)
        {
            var json = _serviceFile.ReadFileCache(path);
            var listOfGuilds = JArray.Parse(json);
            var listOfNpcs = listOfGuilds
                .Where(g => g[Constant.Name].ToString() == guildName)
                .Select(g => g[Constant.Npcs])
                .FirstOrDefault() as JArray;
            return listOfNpcs;
        }

        public JObject RetrieveTypes(string path)
        {
            var json = _serviceFile.ReadFileCache(path);
            return JObject.Parse(json);
        }

    }
}
