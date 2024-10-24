using CarCrashChecker.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarCrashChecker.Data
{
    public class CarDbContext : DbContext
    { 
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) {}
        public DbSet<Car> Car { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(cp => cp.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
