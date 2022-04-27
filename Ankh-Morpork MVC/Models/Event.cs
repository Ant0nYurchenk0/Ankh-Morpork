using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Models
{
    public class Event
    {
        public int Id { get; set; }
        public Character Character { get; set; }
        public int CharacterId { get; set; }
        public double PlayerMoney { get; set; }
        public double PlayerBeer { get; set; }
        public double PlayerHood { get; set; }
        public int Score { get; set; }


    }
}