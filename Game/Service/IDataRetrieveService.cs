using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Game.Service
{
    public interface IDataRetrieveService
    {
        JArray RetrieveNpcs(string guildName, string json);
        Dictionary<string, string> RetrieveMessages(JObject npc) ;
        JObject RetrieveTypes(string path);
        string RetrieveGuildData(string fieldName, string guildName, string path);
        decimal RetrieveFromType(string clownTypesPath, string v);
    }
}