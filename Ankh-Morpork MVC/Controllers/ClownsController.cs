using Ankh_Morpork_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Controllers
{
    public class ClownsController : Controller
    {
        private ClownRepository _repository;
        public ClownsController()
        {
            _repository = new ClownRepository();
        }
        [Route("Clowns/Accept/{reward}")]
        public ActionResult Accept(double reward)
        {
            _repository.AddReward(reward);
            if (!_repository.ProcessResponce(accept: true))
                return Deny();
            return RedirectToAction("CreateEvent", "Events");
        }
        public ActionResult Deny()
        {
            return RedirectToAction("CreateEvent", "Events");
        }
    }
}
