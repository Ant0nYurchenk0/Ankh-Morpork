using Ankh_Morpork_MVC.Models;
using Ankh_Morpork_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Controllers
{
    public class HomeController : Controller
    {
        private GameDbContext _context;
        private GameRepository _repository;
        public HomeController()
        {
            _context = new GameDbContext();   
            _repository = new GameRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartGame()
        {            
            return RedirectToAction("CreateEvent", "Events");
        }

        [Route("GameOver")]
        public ActionResult GameOver()
        {
            if(_context.Events.Count() > 0)
            {
                LogGame();
                ClearEvents();
            }
            return View("GameOver");
        }


        [Route("Statistics")]
        public ActionResult Statistics()
        {
            var games = _context.Games.OrderByDescending(g=>g.Id).Take(10).ToList();
            return View(games);
        }
        public ActionResult ResetPlayer()
        {
            foreach(var game in _context.Games)
                _context.Games.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private void LogGame()
        {
            _repository.ResetGame();
            _repository.AddDate();
            _repository.AddScore();
            _repository.PostGame();
        }
        private void ClearEvents()
        {
            foreach(var e in _context.Events)
                _context.Events.Remove(e);
            _context.SaveChanges();
        }

    }
}