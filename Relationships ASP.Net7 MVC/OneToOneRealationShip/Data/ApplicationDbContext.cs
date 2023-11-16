using Microsoft.EntityFrameworkCore;
using OneToOneRealationShip.Models;

namespace OneToOneRealationShip.Data
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-TD5AD61;Database=OneToOne;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Backpack> Backpacks { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Faction> Factions { get; set; }
    }
}
