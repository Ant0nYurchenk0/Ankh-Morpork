using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Models
{
    public class Item : Character
    {
        public ItemTypes? ItemType { get; set; }
        public double? Price { get; set; }
    }
}