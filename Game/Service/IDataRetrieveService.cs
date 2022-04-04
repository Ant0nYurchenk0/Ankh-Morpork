using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Game
{
    public interface IDataRetrieveService
    {
        JArray RetrieveNpcs(string guildName, string json);
        Dictionary<string, string> RetrieveMessages(JObject npc) ;
        JObject RetrieveTypes(string path);
        string RetrieveGuildData(string fieldName, string guildName, string Json);
        double RetrieveFromType(string clownTypesPath, string v);
    }
}