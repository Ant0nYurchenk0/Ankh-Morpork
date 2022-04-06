using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ThieveBuilder : IThieveBuilder
    {
        private ThieveNpc _npc;

        public void AddGuild(IThievesGuild guild)
        {
            _npc.Guild = guild;
        }

        public void AddMessages(Dictionary<string, string> messages)
        {
            if (messages == null) return;
            _npc.Messages[Constant.MeetMessage] = messages[Constant.MeetMessage];
            _npc.Messages[Constant.AcceptMessage] = messages[Constant.AcceptMessage];
            _npc.Messages[Constant.DenyMessage] = messages[Constant.DenyMessage];
        }

        public void AddName(string name)
        {
            _npc.Name = name;
        }

        public ThieveNpc GetNpc()
        {
            return _npc;
        }

        public void Reset()
        {
            _npc = new ThieveNpc();
        }
    }
}
