using Ankh_Morpork_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Repositories
{
    public class GameRepository : IGameRepository
    {
        private IGameDbContext _context;
        private Game _game;
        public GameRepository(IGameDbContext context)
        {
            _context = context;
        }
        public void AddDate()
        {
            _game.DatePlayed = DateTime.Now;
        }
        public void AddScore()
        {
            var lastEvent = _context.Events
                .Where(e => e.Id == _context.Events.Max(m => m.Id))
                .FirstOrDefault();
            _game.Score = lastEvent.Score;
        }

        public void PostGame()
        {
            _context.Games.Add(_game);
            _context.SaveChanges();
        }
        public void ResetGame()
        {
            _game = new Game();
        }

    }
}