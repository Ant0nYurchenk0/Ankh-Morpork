using Ankh_Morpork_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Controllers
{
    public class HomeController : Controller
    {
        private CharacterDbContext _context;
        public HomeController()
        {
            _context = new CharacterDbContext();   
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartGame()
        {            
            return RedirectToAction("CreateEvent", "Events");
        }

        [Route("")]
        public ActionResult GameOver()
        {
            ClearEvents();
            return View("Index");
        }

        private void ClearEvents()
        {
            foreach(var e in _context.Events)
                _context.Events.Remove(e);
            _context.SaveChanges();
        }
    }
}