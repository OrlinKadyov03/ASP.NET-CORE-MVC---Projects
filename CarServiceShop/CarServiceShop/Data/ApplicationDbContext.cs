using CarServiceShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceShop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
