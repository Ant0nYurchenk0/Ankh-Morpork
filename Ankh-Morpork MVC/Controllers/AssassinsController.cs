using Ankh_Morpork_MVC.Models;
using Ankh_Morpork_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Controllers
{
    public class AssassinsController : Controller
    {
        private IAssassinRepository _repository;
        public AssassinsController(IAssassinRepository repository)
        {
            _repository = repository;

        }

        [Route("Assassins/Accept/{reward}/{hood}")]
        public ActionResult Accept(double reward, bool hood)
        {            
            _repository.AddReward(reward, hood);
            if (!_repository.ProcessResponce(accept: true))
                return Deny();
            return RedirectToAction("CreateEvent", "Events");
        }
        public ActionResult Deny()
        {
            return RedirectToAction("GameOver", "Home");
        }
    }
}