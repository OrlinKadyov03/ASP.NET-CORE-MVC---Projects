using AppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-TD5AD61;Database=Db;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Person> persons { get; set; }
    }
}
