using System.Data.Entity;

namespace Ankh_Morpork_MVC.Models
{
    public class GameDbContext : DbContext, IGameDbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Assassin> Assassins { get; set; }
        public DbSet<Thief> Thieves { get; set; }
        public DbSet<Clown> Clowns { get; set; }
        public DbSet<Beggar> Beggars { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}