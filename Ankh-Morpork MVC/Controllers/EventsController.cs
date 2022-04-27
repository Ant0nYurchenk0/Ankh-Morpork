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
        private GameDbContext _context;
        private EventRepository _eventRepository;
        public EventsController()
        {
            _context = new GameDbContext(); 
            _eventRepository = new EventRepository();
        }        

        [Route("Events/New")]
        public ActionResult CreateEvent()
        {            
            _eventRepository.ResetEvent();
            _eventRepository.AddBody();
            if (_context.Events.Count() == 0)
            {
                _eventRepository.AddMoney(Values.PlayerMoney);
                _eventRepository.AddBeer(Values.PlayerBeer);
                _eventRepository.AddHood(Values.PlayerHood);                
            }
            else
            {
                var lastEvent = _context.Events
                .Where(e => e.Id == _context.Events.Max(m => m.Id))
                .FirstOrDefault();
                _eventRepository.AddMoney(lastEvent.PlayerMoney);
                _eventRepository.AddBeer(lastEvent.PlayerBeer);
                _eventRepository.AddHood(lastEvent.PlayerHood);
                _eventRepository.AddScore(lastEvent.Score);
            }
            _eventRepository.PostEvent();
            return View(_eventRepository.ViewEvent(), Mapper.Map<Event, EventDto>(_eventRepository.GetEvent()));
        }
    }
}