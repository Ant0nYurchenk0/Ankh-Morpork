using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Models
{
    public class Beggar : Character
    {
        public double? MoneyFee { get; set; }
        public bool? BeerFee { get; set; }
    }
}