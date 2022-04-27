using Ankh_Morpork_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Repositories
{
    public class AssassinRepository : IEventProcessRepository
    {
        private GameDbContext _context;
        private Random _random;
        private double _reward;
        private bool _hood;

        public AssassinRepository()
        {
            _context = new GameDbContext();
            _random = new Random();

        }

        public bool ProcessResponce(bool accept)
        {
            if (!accept || !TryApplyReward(_reward))
                return false;
            return true;
        }

        public void AddReward(double reward, bool hood)
        {
            _reward = reward;
            _hood = hood;
        }

        private bool TryApplyReward(double reward)
        {
            RandomizeBusiness();
            var currentEvent = _context.Events
                .Where(e => e.Id == _context.Events.Max(m => m.Id))
                .FirstOrDefault();
            if (_hood)
            {
                currentEvent.PlayerHood--;
                _context.SaveChanges();
                if (currentEvent.PlayerHood < 0)
                    return false;
                return true;
            }
            currentEvent.PlayerMoney -= reward;
            _context.SaveChanges();
            if ((currentEvent.PlayerMoney) < 0)
                return false;
            var assassins = _context.Assassins.ToList();
            if (assassins.Any(a => a.IsBusy == false
                && (a.MinReward <= reward && a.MaxReward >= reward)))
                return true;
            return false;
        }

        private void RandomizeBusiness()
        {
            foreach (var assassin in _context.Assassins)
            {
                assassin.IsBusy = Convert.ToBoolean(_random.Next(2));
            }
            _context.SaveChanges();

        }
    }
}