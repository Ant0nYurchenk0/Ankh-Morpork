using Ankh_Morpork_MVC.Repositories;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Controllers
{
    public class ClownsController : Controller
    {
        private IClownRepository _repository;
        public ClownsController(IClownRepository repository)
        {
            _repository = repository;
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
