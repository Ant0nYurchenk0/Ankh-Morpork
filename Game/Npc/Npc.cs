using System;
using System.Collections.Generic;

namespace Game
{
    public abstract class Npc : INpc
    {
        public string Name { get; set; }

        public Dictionary<string, string> Messages { get; set; }

        protected IView _view;
        public Npc(IView view = null)
        {
            Messages = new Dictionary<string, string>();
            _view = view ?? new View();
        }

        public virtual void Accept(IPlayer player)
        {
            player.IncreaseScore();
        }

        public virtual void Deny(IPlayer player)
        {
            try
            {
                _view.ShowMessage(Messages[Constant.DenyMessage]);
            }
            catch(Exception) { }
            finally
            {
            player.IsAlive = false;
            }
        }
    }
}
