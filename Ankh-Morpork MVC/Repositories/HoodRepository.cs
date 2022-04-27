using Ankh_Morpork_MVC.Constants;
using Ankh_Morpork_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Repositories
{
    public class HoodRepository : IEventProcessRepository
    {
        private GameDbContext _context;
        private double _fee;

        public HoodRepository()
        {
            _context = new GameDbContext();
        }

        public bool ProcessResponce(bool accept)
        {
            if (!accept || !TryApply())
                return false;
            return true;
        }

        internal void AddFee(double fee)
        {
            _fee = fee;
        }

        private bool TryApply()
        {
            var currentEvent = _context.Events
                .Where(e => e.Id == _context.Events.Max(m => m.Id))
                .FirstOrDefault();
            if ((currentEvent.PlayerHood) >= Values.MaxHoods)
                return false;
            if ((currentEvent.PlayerMoney -= _fee) < 0)
                return false;
            currentEvent.PlayerHood += 1;
            _context.SaveChanges();
            return true;
        }
    }
}