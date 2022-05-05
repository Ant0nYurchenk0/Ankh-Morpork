using Ankh_Morpork_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Repositories
{
    public class ThiefRepository : IEventProcessRepository, IThiefRepository
    {
        private IGameDbContext _context;
        private double _fee;

        public ThiefRepository(IGameDbContext context)
        {
            _context = context;

        }

        public bool ProcessResponce(bool accept)
        {
            if (!accept || !TryApplyFee())
                return false;
            return true;
        }

        public void AddFee(double fee)
        {
            _fee = fee;
        }

        private bool TryApplyFee()
        {
            var currentEvent = _context.Events
                .Where(e => e.Id == _context.Events.Max(m => m.Id))
                .FirstOrDefault();
            currentEvent.PlayerMoney -= _fee;
            _context.SaveChanges();
            if ((currentEvent.PlayerMoney) < 0)
                return false;
            return true;
        }
    }
}