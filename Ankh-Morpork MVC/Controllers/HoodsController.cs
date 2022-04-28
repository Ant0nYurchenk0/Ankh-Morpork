﻿using Ankh_Morpork_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Controllers
{
    public class HoodsController : Controller
    {
        private HoodRepository _repository;
        public HoodsController()
        {
            _repository = new HoodRepository();
        }
        [HttpPost]
        [Route("Hoods/Accept/{fee}")]
        public ActionResult Accept(double fee)
        {
            _repository.AddFee(fee);
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