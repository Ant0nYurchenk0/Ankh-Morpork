using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class AssassinBuilder : IAssassinBuilder
    {
        public AssassinNpc _npc;

        public void AddGuild(IAssassinsGuild guild)
        {
            _npc.Guild = guild;
        }
        public void AddMaxReward(double reward)
        {
            _npc.MaxReward = reward;
        }
        public void AddMinReward(double reward)
        {
            _npc.MinReward = reward;
        }
        public void AddMessages(Dictionary<string, string> messages)
        {
            if (messages == null) return;
            _npc.Messages[Constant.MeetMessage] = messages[Constant.MeetMessage];
            _npc.Messages[Constant.AcceptMessage] = messages[Constant.AcceptMessage];
            _npc.Messages[Constant.DenyMessage] = messages[Constant.DenyMessage];
            _npc.Messages[Constant.OfferMessage] = messages[Constant.OfferMessage];
        }

        public void AddName(string name)
        {
            _npc.Name = name;
        }
        public void Reset(IView view = null)
        {
            _npc = new AssassinNpc(view);
            _npc.IsBusy = false;
        }
        public AssassinNpc GetNpc()
        {
            return _npc;
        }
    }
}
