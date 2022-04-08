using System.Linq;
using System.Collections.Generic;
using Game.Players;
using Game.Views;
using Game.Constants;


namespace Game.Npcs
{
    public abstract class Npc : INpc
    {
        public string Name { get; set; }

        public Dictionary<string, string> Messages { get; set; }

        protected IView _view;
        protected Npc()
        {
            Messages = new Dictionary<string, string>();
            _view =  new View();
        }

        public virtual void Accept(IPlayer player)
        {
            player.IncreaseScore();
        }

        public virtual void Deny(IPlayer player)
        {
            _view.ShowMessage(Messages.FirstOrDefault(m => m.Key == Constant.DenyMessage).Value);
            player.IsAlive = false;
            
        }
    }
}
