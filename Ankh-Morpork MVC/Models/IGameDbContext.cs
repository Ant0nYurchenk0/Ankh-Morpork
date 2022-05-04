using System.Data.Entity;

namespace Ankh_Morpork_MVC.Models
{
    public interface IGameDbContext
    {
        DbSet<Assassin> Assassins { get; set; }
        DbSet<Beggar> Beggars { get; set; }
        DbSet<Clown> Clowns { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Thieve> Thieves { get; set; }
        int SaveChanges();
    }
}