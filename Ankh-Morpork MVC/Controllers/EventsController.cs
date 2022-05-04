using Ankh_Morpork_MVC.Models;
using Ankh_Morpork_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ankh_Morpork_MVC.Constants;
using AutoMapper;
using Ankh_Morpork_MVC.Dtos;

namespace Ankh_Morpork_MVC.Controllers
{
    public class EventsController : Controller
    {
        private IGameDbContext _context;
        private IEventRepository _repository;
        public EventsController(IGameDbContext context, IEventRepository repository)
        {
            _context = context;
            _repository = repository;
        }        

        [Route("Events/New")]
        public ActionResult CreateEvent()
        {            
            _repository.ResetEvent();
            _repository.AddBody();
            if (_context.Events.Count() == 0)
            {
                _repository.AddMoney(Values.PlayerMoney);
                _repository.AddBeer(Values.PlayerBeer);
                _repository.AddHood(Values.PlayerHood);                
            }
            else
            {
                var lastEvent = _context.Events
                .Where(e => e.Id == _context.Events.Max(m => m.Id))
                .FirstOrDefault();
                _repository.AddMoney(lastEvent.PlayerMoney);
                _repository.AddBeer(lastEvent.PlayerBeer);
                _repository.AddHood(lastEvent.PlayerHood);
                _repository.AddScore(lastEvent.Score);
                _repository.SetThievesMet(lastEvent.ThievesMet);
            }
            _repository.PostEvent();
            return View(_repository.ViewEvent(), Mapper.Map<Event, EventDto>(_repository.GetEvent()));
        }
    }
}