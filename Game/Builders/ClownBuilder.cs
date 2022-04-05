using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ClownBuilder : IClownBuilder
    {
        private ClownNpc _npc;

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

        public void AddReward(decimal reward)
        {
            _npc.Reward = reward;
        }

        public ClownNpc GetNpc()
        {
            return _npc;
        }

        public void Reset(IView view = null)
        {
            _npc = new ClownNpc(view);
        }
    }
}
