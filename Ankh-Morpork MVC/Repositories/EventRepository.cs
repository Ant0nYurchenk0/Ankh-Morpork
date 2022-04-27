using Ankh_Morpork_MVC.Dtos;
using Ankh_Morpork_MVC.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ankh_Morpork_MVC.Repositories
{
    public class EventRepository
    {
        private Event _event;
        private CharacterDbContext _context = new CharacterDbContext();
        private Random _random = new Random();
        private string _viewName;
        
        public void AddCharacter()
        {
            Array charTypeValues = Enum.GetValues(typeof(CharacterTypes));
            CharacterTypes randomCharType = (CharacterTypes)charTypeValues
                .GetValue(_random.Next(charTypeValues.Length));
            switch (randomCharType)
            {
                case CharacterTypes.Assassin:
                    var randomIndex = _random.Next(_context.Assassins.Count());
                    var charArray = _context.Assassins.ToArray();
                    _event.Character = charArray[randomIndex];
                    _viewName = "..\\Assassins\\NewAssassin";
                    break;
                default:
                    break;
            }
        }
        public void AddMoney(double money)
        {
            _event.PlayerMoney = money;
        }
        public void ResetEvent()
        {
            _event = new Event(); 
        }
        public void PostEvent()
        {
            _context.Events.Add(_event);
            _context.SaveChanges();
        }                    
        public string ViewEvent() => _viewName;
        public Event GetEvent() => _event;
        
    }
}