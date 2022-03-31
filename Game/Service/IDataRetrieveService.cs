using Newtonsoft.Json.Linq;

namespace Game
{
    public interface IDataRetrieveService
    {
        JArray RetrieveNpcs(string guildName, string json);
        JObject RetrieveTypes(string path);
        string RetrieveGuildData(string fieldName, string guildName, string Json);

    }
}