using Ankh_Morpork_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Controllers
{
    public class BeggarsController : Controller
    {
        private BeggarsRepository _repository;
        public BeggarsController()
        {
            _repository = new BeggarsRepository();
        }
        [HttpPost]
        [Route("Beggars/Accept/{moneyFee}/{beerFee}")]
        public ActionResult Accept(double moneyFee, bool beerFee)
        {
            _repository.AddFees(moneyFee, beerFee);
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