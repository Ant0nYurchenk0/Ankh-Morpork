using Ankh_Morpork_MVC.Constants;
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
        private GameDbContext _context = new GameDbContext();
        private Random _random = new Random();
        private string _viewName;
        
        public void AddBody()
        {
            if ((IsItem()) == true)
                AddItem();
            else
                AddCharacter();
            
        }

        private void AddItem()
        {
            Array itemTypeValues = Enum.GetValues(typeof(ItemTypes));
            ItemTypes randomItemType = (ItemTypes)itemTypeValues
                .GetValue(_random.Next(itemTypeValues.Length));
            switch (randomItemType)
            {
                case ItemTypes.Beer:
                    CreateBeer();
                    break;
                case ItemTypes.Hood:
                    CreateHood();
                    break;
                default:
                    break;
            }
        }


        internal void AddHood(double playerHood)
        {
            _event.PlayerHood = playerHood;
        }

        private void AddCharacter()
        {
            Array charTypeValues = Enum.GetValues(typeof(CharacterTypes));
            CharacterTypes randomCharType = (CharacterTypes)charTypeValues
                .GetValue(_random.Next(charTypeValues.Length));
            switch (randomCharType)
            {
                case CharacterTypes.Assassin:
                    CreateAssassin();
                    break;
                case CharacterTypes.Thieve:
                    CreateThieve();
                    break;
                case CharacterTypes.Clown:
                    CreateClown();
                    break;
                case CharacterTypes.Beggar:
                    CreateBeggar();
                    break;
            }
        }

        internal void AddScore(int score)
        {
            _event.Score+=(score+1);
        }

        internal void AddBeer(double playerBeer)
        {
            _event.PlayerBeer = playerBeer;
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
        private void CreateHood()
        {
            var randomIndex = _random.Next(_context.Items.Count(i => i.ItemType == ItemTypes.Hood));
            var charArray = _context.Items.ToArray();
            _event.Character = charArray[randomIndex];
            _viewName = "..\\Hoods\\NewHood";
        }

        private void CreateBeer()
        {
            var randomIndex = _random.Next(_context.Items.Count(i=>i.ItemType == ItemTypes.Beer));
            var charArray = _context.Items.ToArray();
            _event.Character = charArray[randomIndex];
            _viewName = "..\\Beers\\NewBeer";
        }
        private void CreateAssassin()
        {
            var randomIndex = _random.Next(_context.Assassins.Count());
            var charArray = _context.Assassins.ToArray();
            _event.Character = charArray[randomIndex];
            _viewName = "..\\Assassins\\NewAssassin";
        }
        private void CreateThieve()
        {                            
            var randomIndex = _random.Next(_context.Thieves.Count());
            var charArray = _context.Thieves.ToArray();
            _event.Character = charArray[randomIndex];
            _viewName = "..\\Thieves\\NewThieve";
        }
        private void CreateClown()
        {
            var randomIndex = _random.Next(_context.Clowns.Count());
            var charArray = _context.Clowns.ToArray();
            _event.Character = charArray[randomIndex];
            _viewName = "..\\Clowns\\NewClown";
        }
        private void CreateBeggar()
        {
            var randomIndex = _random.Next(_context.Beggars.Count());
            var charArray = _context.Beggars.ToArray();
            _event.Character = charArray[randomIndex];
            _viewName = "..\\Beggars\\NewBeggar";
        }      
        private bool IsItem()
        {
            var percents = 100;
            var probArray = new int[percents];
            for (var i = 0; i < Values.ItemProbability; i++)
                probArray[i] = 1;
            var randomIndex = _random.Next(percents);
            if (probArray[randomIndex] == 1)
            {
                _event.CharacterId = 0;
                return true;
            }
            return false;
        }
    }
}