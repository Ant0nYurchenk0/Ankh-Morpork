using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Models
{
    public abstract class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeetMessage { get; set; }
        public string GuildData { get; set; }
    }
}