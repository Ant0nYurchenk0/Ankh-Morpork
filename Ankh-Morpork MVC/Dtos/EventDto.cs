using Ankh_Morpork_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Dtos
{
    public class EventDto
    {
        public Character Character { get; set; }
        public double PlayerMoney { get; set; }
        public double PlayerBeer{ get; set; }
        public double PlayerHood{ get; set; }
        public double Reward { get; set; }
        public int Score { get; set; }
    }
}