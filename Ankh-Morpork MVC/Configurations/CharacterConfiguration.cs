using Ankh_Morpork_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Ankh_Morpork_MVC.Configurations
{
    public class CharacterConfiguration : EntityTypeConfiguration<Assassin>
    {
        public CharacterConfiguration()
        {
        }
    }
}