using System.Collections.Generic;

namespace Game.Builders
{
    public interface INpcBuilder<TNpc>
    {
        void Reset();
        void AddMessages(Dictionary<string, string> messages);
        void AddName(string name);
        TNpc GetNpc();
    }
}
