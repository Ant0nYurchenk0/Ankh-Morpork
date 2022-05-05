using Game.Constants;
using Game.Guilds;
using Game.Npcs;
using System.Collections.Generic;

namespace Game.Builders
{
    public class AssassinBuilder : INpcBuilder<AssassinNpc>
    {
        public AssassinNpc _npc;

        public void AddGuild(IAssassinsGuild guild)
        {
            _npc.Guild = guild;
        }

        public void AddMaxReward(decimal reward)
        {
            _npc.MaxReward = reward;
        }

        public void AddMinReward(decimal reward)
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

        public void Reset()
        {
            _npc = new AssassinNpc();
            _npc.IsBusy = false;
        }

        public AssassinNpc GetNpc()
        {
            return _npc;
        }
    }
}
