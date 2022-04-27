using Ankh_Morpork_MVC.Models;
using Ankh_Morpork_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Controllers
{
    public class AssassinsController : Controller
    {
        private AssassinRepository _repository;
        public AssassinsController()
        {
            _repository = new AssassinRepository();
        }

        [HttpPost]
        [Route("Assassins/Accept/{reward}")]
        public ActionResult Accept(double reward)
        {            
            _repository.AddReward(reward);
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