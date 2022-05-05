using Game.Constants;
using Game.Npcs;
using System.Collections.Generic;


namespace Game.Builders
{
    public class BeggarBuilder : INpcBuilder<BeggarNpc>
    {
        private BeggarNpc _npc;

        public void AddFee(decimal fee)
        {
            _npc.Fee = fee;
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

        public BeggarNpc GetNpc()
        {
            return _npc;
        }

        public void Reset()
        {
            _npc = new BeggarNpc();
        }
    }
}
