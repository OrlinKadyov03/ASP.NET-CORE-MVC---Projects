using Microsoft.EntityFrameworkCore;
using RaceRunApp.Models;

namespace RaceRunApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Race> Races { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Address> Addresss { get; set; }
    }
}
