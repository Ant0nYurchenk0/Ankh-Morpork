using Ankh_Morpork_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Repositories
{
    public class ClownRepository :  IClownRepository
    {
        private IGameDbContext _context;
        private double _reward;

        public ClownRepository(IGameDbContext context)
        {
            _context = context;
        }

        public bool ProcessResponce(bool accept)
        {
            if (!accept || !TryApplyReward())
                return false;
            return true;
        }

        public void AddReward(double reward)
        {
            _reward = reward;
        }

        private bool TryApplyReward()
        {
            var currentEvent = _context.Events
                .Where(e => e.Id == _context.Events.Max(m => m.Id))
                .FirstOrDefault();
            currentEvent.PlayerMoney += _reward;
            _context.SaveChanges();
            if ((currentEvent.PlayerMoney) < 0)
                return false;
            return true;
        }
    }
}
