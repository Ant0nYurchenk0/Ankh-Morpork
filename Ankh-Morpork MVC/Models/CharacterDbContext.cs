using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Ankh_Morpork_MVC.Configurations;

namespace Ankh_Morpork_MVC.Models
{
    public class CharacterDbContext : DbContext
    {
        public DbSet<Assassin> Assassins { get; set; }
        public DbSet<Thieve> Thieves { get; set; }
        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AssassinConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}