using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class DataRetrieveService : IDataRetrieveService
    {
        private IFileService _serviceFile;
        public DataRetrieveService(IFileService serviceFile = null)
        {
            _serviceFile = serviceFile ?? new FileService();
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
            var json = _serviceFile.ReadFileCache(Config.BeggarTypesPath);
            return JObject.Parse(json);
        }
    }
}
