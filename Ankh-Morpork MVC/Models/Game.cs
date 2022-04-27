using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Models
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime DatePlayed { get; set; }
        public int Score { get; set; }
    }
}