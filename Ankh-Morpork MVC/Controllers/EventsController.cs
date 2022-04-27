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
        // GET: Events
        private CharacterDbContext _context;
        private EventRepository _eventRepository;
        public EventsController()
        {
            _context = new CharacterDbContext(); 
            _eventRepository = new EventRepository();
        }        

        [Route("Events/New")]
        public ActionResult CreateEvent()
        {            
            _eventRepository.ResetEvent();
            _eventRepository.AddCharacter();
            if (_context.Events.Count() == 0)
                _eventRepository.AddMoney(Values.PlayerMoney);
            else
                _eventRepository.AddMoney(_context.Events
                .Where(e => e.Id == _context.Events.Max(m => m.Id))
                .FirstOrDefault().PlayerMoney);
            _eventRepository.PostEvent();
            return View(_eventRepository.ViewEvent(), Mapper.Map<Event, EventDto>(_eventRepository.GetEvent()));
        }
    }
}