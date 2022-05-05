using Ankh_Morpork_MVC.Models;
using System.Linq;

namespace Ankh_Morpork_MVC.Repositories
{
    public class BeggarRepository : IBeggarsRepository
    {
        private IGameDbContext _context;
        private double _moneyFee;
        private bool _beerFee;

        public BeggarRepository(IGameDbContext context)
        {
            _context = context;
        }

        public bool ProcessResponce(bool accept)
        {
            if (!accept || !TryApplyFees())
                return false;
            return true;
        }

        public void AddFees(double fee, bool beerFee)
        {
            _moneyFee = fee;
            _beerFee = beerFee;
        }

        private bool TryApplyFees()
        {
            var currentEvent = _context.Events
                .Where(e => e.Id == _context.Events.Max(m => m.Id))
                .FirstOrDefault();
            currentEvent.PlayerMoney -= _moneyFee;
            if (_beerFee)
                currentEvent.PlayerBeer--;
            _context.SaveChanges();
            if ((currentEvent.PlayerMoney) < 0)
                return false;
            if ((currentEvent.PlayerBeer) < 0)
                return false;
            return true;
        }
    }
}