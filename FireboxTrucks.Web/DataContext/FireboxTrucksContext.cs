using FireboxTrucks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace FireboxTrucks.Web.DataContext
{
    public class FireboxTrucksContext : DbContext
    {
        public FireboxTrucksContext(DbContextOptions<FireboxTrucksContext> options) : base(options)
        {

        }
        public DbSet<Caminhao> Caminhao { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Caminhao>();
            //modelBuilder.Entity<Modelo>();
        }
    }
}
