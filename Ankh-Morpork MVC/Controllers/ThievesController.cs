using Ankh_Morpork_MVC.Repositories;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Controllers
{
    public class ThievesController : Controller
    {
        private IThiefRepository _repository;
        public ThievesController(IThiefRepository repository)
        {
            _repository = repository;
        }
        [HttpPost]
        [Route("Thieves/Accept/{fee}")]
        public ActionResult Accept(double fee)
        {
            _repository.AddFee(fee);
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